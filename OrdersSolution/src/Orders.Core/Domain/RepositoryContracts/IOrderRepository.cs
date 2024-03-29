﻿using Orders.Core.Domain.Entities.Orders;

namespace Orders.Core.Domain.RepositoryContracts
{
    public interface IOrderRepository
    {
        Task<List<Order>?> GetAllOrders();

        Task<Order?> GetOrder(Guid orderId);

        Task<int> CreateOrder(Order order);

        Task<int> UpdateOrder(Guid orderId, Order order);

        Task<int> DeleteOrder(Guid orderId);
    }
}
