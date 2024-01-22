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
		private readonly IMapper _mapper;

        public OrderService(
				IOrderRepository orderRepository
			)
        {
            _orderRepository = orderRepository;
			_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())));
		}

        public async Task<Guid> CreateOrder(OrderAddRequest? orderAddRequest)
		{
			await ValidationHelper.ValidateObjects(orderAddRequest);

			var order = new Order()
			{
				CustomerName = orderAddRequest!.CustomerName,
				Id = Guid.NewGuid(),
				OrderNumber = await GenerateOrderNumber(),
				PlacedDate = DateTime.Now,
				TotalAmount = 0
			};

			var affected = await _orderRepository.CreateOrder(order);

			if (affected != 1)
			{
				throw new InvalidOperationException("Error with the database");
			}

			return order.Id;
		}

		public async Task<bool> DeleteOrder(Guid? orderId)
		{
			await ValidationHelper.ValidateObjects(orderId);

			var order = await _orderRepository.GetOrder(orderId!.Value);

			if (order is null)
			{
				throw new ArgumentException("Unable to delete order. OrderId is invalid.");
			}

			var affected = await _orderRepository.DeleteOrder(orderId!.Value);

			return affected == 1;
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

			if (affected != 1)
			{
				throw new InvalidOperationException("Error with the database");
			}

			return order.Id;
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
