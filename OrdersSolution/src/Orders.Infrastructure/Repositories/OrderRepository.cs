using Microsoft.EntityFrameworkCore;
using Orders.Core.Domain.Entities.Orders;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Infrastructure.Db;

namespace Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOrder(Order order)
		{
			_dbContext.Orders.Add(order);

			return await _dbContext.SaveChangesAsync();
		}

		public async Task<int> DeleteOrder(Guid orderId)
		{
			var order = await GetOrder(orderId);

			_dbContext.Orders.Remove(order);

			return await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Order>?> GetAllOrders()
		{
			return await _dbContext.Orders.ToListAsync();
		}

		public async Task<Order?> GetOrder(Guid orderId)
		{
			var order = await _dbContext.Orders.FindAsync(orderId);

			return order;
		}

		public async Task<int> UpdateOrder(Guid orderId, Order order)
		{
			var foundOrder = await GetOrder(orderId);

			await CopyProperties(order, foundOrder);

			return await _dbContext.SaveChangesAsync();
		}

		private async Task CopyProperties(Order from, Order to)
		{
			to.OrderNumber = from.OrderNumber;
			to.CustomerName = from.CustomerName;
			to.PlacedDate = from.PlacedDate;
			to.Id = from.Id;
			to.TotalAmount = from.TotalAmount;

			await Task.CompletedTask;
		}
	}
}
