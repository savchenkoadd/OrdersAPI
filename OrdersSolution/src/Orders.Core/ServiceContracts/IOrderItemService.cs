using Orders.Core.Domain.Entities.Orders;
using Orders.Core.DTO.OrderItem;

namespace Orders.Core.ServiceContracts
{
	public interface IOrderItemService
	{
		Task<List<OrderItemResponse>> GetOrderItemsByOrderId(Guid? orderId);

		Task<OrderItemResponse> GetOrderItem(Guid? orderItemId);

		Task<bool> CreateOrderItem(OrderItemAddRequest? orderItemAddRequest);

		Task<bool> UpdateOrderItem(Guid? orderItemId, OrderItemUpdateRequest? orderItemUpdateRequest);

		Task<bool> DeleteOrderItem(Guid? orderItemId);
	}
}
