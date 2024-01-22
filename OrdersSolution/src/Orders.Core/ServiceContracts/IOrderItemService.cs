using Orders.Core.Domain.Entities.Orders;
using Orders.Core.DTO.OrderItem;

namespace Orders.Core.ServiceContracts
{
	public interface IOrderItemService
	{
		Task<List<OrderItemResponse>> GetOrderItemsByOrderId(Guid? orderId);

		Task<OrderItemResponse> GetOrderItem(Guid? orderItemId);

		Task<Guid> CreateOrderItem(OrderItemAddRequest? orderItemAddRequest);

		Task<Guid> UpdateOrderItem(Guid? orderItemId, OrderItemUpdateRequest? orderItemUpdateRequest);

		Task DeleteOrderItem(Guid? orderItemId);
	}
}
