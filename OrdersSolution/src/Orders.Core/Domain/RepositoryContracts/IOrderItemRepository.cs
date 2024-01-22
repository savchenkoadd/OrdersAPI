using Orders.Core.Domain.Entities.Orders;

namespace Orders.Core.Domain.RepositoryContracts
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>?> GetOrderItemsByOrderId(Guid orderId);

        Task<OrderItem?> GetOrderItem(Guid orderItemId);

        Task<bool> Exists(Guid orderItemId);

        Task<int> CreateOrderItem(OrderItem orderItem);

        Task<int> UpdateOrderItem(Guid orderItemId, OrderItem orderItem);

        Task<int> DeleteOrderItem(Guid orderItemId);
    }
}
