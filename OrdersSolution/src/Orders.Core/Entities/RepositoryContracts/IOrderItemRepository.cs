using Orders.Core.Entities.Orders;

namespace Orders.Core.Entities.RepositoryContracts
{
	public interface IOrderItemRepository
	{
		Task<List<OrderItem>> GetOrderItemsByOrderId(Guid orderId);

		Task<OrderItem> GetOrderItem(Guid orderItemId);

		Task<int> CreateOrderItem(OrderItem orderItem);

		Task<int> UpdateOrderItem(Guid orderItemId, OrderItem orderItem);

		Task<int> DeleteOrderItem(Guid orderItemId);
	}
}
