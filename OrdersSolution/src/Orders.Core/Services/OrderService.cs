using AutoMapper;
using Orders.Core.Domain.Entities.Orders;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.DTO.Order;
using Orders.Core.ServiceContracts;
using Orders.Core.Services.Helpers;
using Orders.Core.Services.Profiles;

namespace Orders.Core.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly IMapper _mapper;

        public OrderService(
				IOrderRepository orderRepository,
				IOrderItemRepository orderItemRepository
			)
        {
            _orderRepository = orderRepository;
			_orderItemRepository = orderItemRepository;
			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())));
		}

        public async Task<Guid> CreateOrder(OrderAddRequest? orderAddRequest)
		{
			await ValidationHelper.ValidateObjects(orderAddRequest);

			var order = new Order()
			{
				CustomerName = orderAddRequest!.CustomerName,
				Id = orderAddRequest!.OrderId,
				OrderNumber = await GenerateOrderNumber(),
				PlacedDate = DateTime.Now,
				TotalAmount = await CalculateTotalCost(orderAddRequest.OrderId)
			};

			var affected = await _orderRepository.CreateOrder(order);

			ResultChecker.CheckAffectedAndThrowIfNeeded(affected);

			return order.Id;
		}

		public async Task DeleteOrder(Guid? orderId)
		{
			await ValidationHelper.ValidateObjects(orderId);

			var order = await _orderRepository.GetOrder(orderId!.Value);

			if (order is null)
			{
				throw new ArgumentException("Unable to delete order. OrderId is invalid.");
			}

			var affected = await _orderRepository.DeleteOrder(orderId!.Value);

			ResultChecker.CheckAffectedAndThrowIfNeeded(affected);
		}

		public async Task<List<OrderResponse>> GetAllOrders()
		{
			var orders = await _orderRepository.GetAllOrders();

			if (orders is null)
			{
				throw new InvalidOperationException("Unable to get all orders.");
			}

			return _mapper.Map<List<OrderResponse>>(orders);
		}

		public async Task<OrderResponse> GetOrder(Guid? orderId)
		{
			await ValidationHelper.ValidateObjects(orderId);

			var order = await _orderRepository.GetOrder(orderId!.Value);

			if (order is null)
			{
				throw new ArgumentException("Invalid order id.");
			}

			return _mapper.Map<OrderResponse>(order);
		}

		public async Task<Guid> UpdateOrder(Guid? orderId, OrderUpdateRequest? orderUpdateRequest)
		{
			await ValidationHelper.ValidateObjects(orderUpdateRequest, orderId);

			var order = await _orderRepository.GetOrder(orderId!.Value);

			if (order is null)
			{
				throw new ArgumentException("Unable to update order. Order id is invalid.");
			}

			order.CustomerName = orderUpdateRequest!.CustomerName;

			var affected = await _orderRepository.UpdateOrder(orderId.Value, order);

			ResultChecker.CheckAffectedAndThrowIfNeeded(affected);

			return order.Id;
		}

		private async Task<double> CalculateTotalCost(Guid orderId)
		{
			var orderItems = await _orderItemRepository.GetOrderItemsByOrderId(orderId);

			if (orderItems is null)
			{
				throw new ArgumentException("Unable to calculate total cost of order. Order id is most likely invalid.");
			}

			double totalCost = 0;

			foreach (var item in orderItems)
			{
				totalCost += item.TotalPrice;
			}

			return totalCost;
		}

		private async Task<string> GenerateOrderNumber()
		{
			Random random = new Random();
			int currentYear = DateTime.Now.Year;

			await Task.CompletedTask;

			return $"Order_{currentYear}_{random.Next(0, int.MaxValue)}";
		}
	}
}
