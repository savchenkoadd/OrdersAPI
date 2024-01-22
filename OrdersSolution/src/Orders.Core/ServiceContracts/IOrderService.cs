using Orders.Core.DTO.Order;

namespace Orders.Core.ServiceContracts
{
	public interface IOrderService
	{
		Task<List<OrderResponse>> GetAllOrders();

		Task<OrderResponse> GetOrder(Guid? orderId);

		Task<Guid> CreateOrder(OrderAddRequest? orderAddRequest);

		Task<Guid> UpdateOrder(Guid? orderId, OrderUpdateRequest? orderUpdateRequest);

		Task<bool> DeleteOrder(Guid? orderId);
	}
}
