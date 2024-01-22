using Microsoft.EntityFrameworkCore;
using Orders.Core.Domain.Entities.Orders;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Infrastructure.Db;

namespace Orders.Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public OrderItemRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> CreateOrderItem(OrderItem orderItem)
		{
			await _dbContext.OrderItems.AddAsync(orderItem);

			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> DeleteOrderItem(Guid orderItemId)
		{
			var foundOrderItem = await GetOrderItem(orderItemId);

			_dbContext.OrderItems.Remove(foundOrderItem);

			return await _dbContext.SaveChangesAsync();
		}

		public async Task<bool> Exists(Guid orderItemId)
		{
			return await _dbContext.OrderItems.AnyAsync(x => x.Id == orderItemId);
		}

		public async Task<OrderItem?> GetOrderItem(Guid orderItemId)
		{
			var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);

			return orderItem;
		}

		public async Task<List<OrderItem>?> GetOrderItemsByOrderId(Guid orderId)
		{
			return await _dbContext.OrderItems.Where(temp => temp.OrderId == orderId).ToListAsync();
		}

		public async Task<int> UpdateOrderItem(Guid orderItemId, OrderItem orderItem)
		{
			var foundOrderItem = await GetOrderItem(orderItemId);

			await CopyProperties(orderItem, foundOrderItem);

			return await _dbContext.SaveChangesAsync();
		}

		private async Task CopyProperties(OrderItem source, OrderItem destination)
		{
			destination.OrderId = source.OrderId;
			destination.UnitPrice = source.UnitPrice;
			destination.Quantity = source.Quantity;
			destination.TotalPrice = source.TotalPrice;
			destination.Id = source.Id;
			destination.ProductName = source.ProductName;

			await Task.CompletedTask;
		}
	}
}
