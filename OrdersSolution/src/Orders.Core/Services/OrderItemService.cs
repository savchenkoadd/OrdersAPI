using AutoMapper;
using Orders.Core.Domain.Entities.Orders;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO.OrderItem;
using Orders.Core.ServiceContracts;
using Orders.Core.Services.Helpers;
using Orders.Core.Services.Profiles;

namespace Orders.Core.Services
{
	public class OrderItemService : IOrderItemService
	{
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly IMapper _mapper;

		public OrderItemService(
				IOrderItemRepository orderItemRepository
			)
        {
			_orderItemRepository = orderItemRepository;
			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())));
		}

        public async Task<Guid> CreateOrderItem(OrderItemAddRequest? orderItemAddRequest)
		{
			await ValidationHelper.ValidateObjects(orderItemAddRequest);

			var orderItem = _mapper.Map<OrderItem>(orderItemAddRequest);

			if (orderItem is null)
			{
				throw new InvalidOperationException("Unable to map order item add request object.");
			}

			orderItem.TotalPrice = orderItem.UnitPrice * orderItem.Quantity;
			orderItem.Id = Guid.NewGuid();

			var affected = await _orderItemRepository.CreateOrderItem(orderItem);

			ResultChecker.CheckAffectedAndThrowIfNeeded(affected);

			return orderItem.Id;
		}

		public async Task DeleteOrderItem(Guid? orderItemId)
		{
			await ValidationHelper.ValidateObjects(orderItemId);

			if (!await _orderItemRepository.Exists(orderItemId!.Value))
			{
				throw new ArgumentException("Unable to delete order item. Order item id seems to be invalid.");
			}

			var affected = await _orderItemRepository.DeleteOrderItem(orderItemId.Value);

			ResultChecker.CheckAffectedAndThrowIfNeeded(affected);
		}

		public async Task<OrderItemResponse> GetOrderItem(Guid? orderItemId)
		{
			await ValidationHelper.ValidateObjects(orderItemId);

			var foundOrderItem = await _orderItemRepository.GetOrderItem(orderItemId!.Value);

			if (foundOrderItem is null)
			{
				throw new ArgumentException("Unable to get order item. Order item id is invalid.");
			}

			return _mapper.Map<OrderItemResponse>(foundOrderItem);
		}

		public async Task<List<OrderItemResponse>> GetOrderItemsByOrderId(Guid? orderId)
		{
			await ValidationHelper.ValidateObjects(orderId);

			var foundOrderItems = await _orderItemRepository.GetOrderItemsByOrderId(orderId!.Value);

			if (foundOrderItems is null || foundOrderItems.Count == 0)
			{
				throw new ArgumentException("Order id is invalid.");
			}

			return _mapper.Map<List<OrderItemResponse>>(foundOrderItems);
		}

		public async Task<Guid> UpdateOrderItem(Guid? orderItemId, OrderItemUpdateRequest? orderItemUpdateRequest)
		{
			await ValidationHelper.ValidateObjects(orderItemId, orderItemUpdateRequest);

			var foundOrderItem = await _orderItemRepository.GetOrderItem(orderItemId!.Value);

			if (foundOrderItem is null)
			{
				throw new ArgumentException("Unable to update order item. Order item id is invalid.");
			}

			foundOrderItem.UnitPrice = orderItemUpdateRequest!.UnitPrice;
			foundOrderItem.OrderId = orderItemUpdateRequest.OrderId;
			foundOrderItem.ProductName = orderItemUpdateRequest.ProductName;
			foundOrderItem.Quantity = orderItemUpdateRequest.Quantity;

			var affected = await _orderItemRepository.UpdateOrderItem(orderItemId.Value, foundOrderItem);

			ResultChecker.CheckAffectedAndThrowIfNeeded(affected);

			return foundOrderItem.OrderId;
		}
	}
}
