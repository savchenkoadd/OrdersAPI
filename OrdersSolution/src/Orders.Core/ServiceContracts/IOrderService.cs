using Orders.Core.DTO.Order;

namespace Orders.Core.ServiceContracts
{
	public interface IOrderService
	{
		Task<List<OrderResponse>> GetAllOrders();

		Task<OrderResponse> GetOrder(Guid? orderId);

		Task<bool> CreateOrder(OrderAddRequest? orderAddRequest);

		Task<bool> UpdateOrder(OrderUpdateRequest? orderUpdateRequest);

		Task<bool> DeleteOrder(Guid? orderId);
	}
}
