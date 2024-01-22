using Microsoft.EntityFrameworkCore;
using Orders.Core.Entities.Orders;

namespace Orders.Infrastructure.Db
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            BindEntitiesToTables(modelBuilder);

			SeedOrdersData(modelBuilder);

			SeedOrderItemsData(modelBuilder);
		}

		private void BindEntitiesToTables(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>().ToTable(nameof(Orders));
			modelBuilder.Entity<OrderItem>().ToTable(nameof(OrderItems));
		}

		private void SeedOrdersData(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>().HasData(
					new Order()
					{
						CustomerName = "John",
						Id = Guid.Parse("D94DEE42-F00A-4361-9668-269A3795CB4A"),
						OrderNumber = "Order_2024_1",
						PlacedDate = DateTime.Now,
						TotalAmount = 1200
					},
					new Order()
					{
						CustomerName = "Mike",
						Id = Guid.Parse("62D513F7-CD0A-4D59-B415-9CF0C67A29E4"),
						OrderNumber = "Order_2024_2",
						PlacedDate = DateTime.Now,
						TotalAmount = 600
					}
				);
		}

		private void SeedOrderItemsData(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItem>().HasData(
					new OrderItem()
					{
						Id = Guid.Parse("72C023C4-0B70-48B1-870C-8FA117F861F1"),
						OrderId = Guid.Parse("D94DEE42-F00A-4361-9668-269A3795CB4A"),
						ProductName = "Laptop",
						Quantity = 1,
						UnitPrice = 1200,
						TotalPrice = 1200
					},
					new OrderItem()
					{
						Id = Guid.Parse("2550EC20-DAA8-4868-8EEC-C84F00041E9C"),
						OrderId = Guid.Parse("62D513F7-CD0A-4D59-B415-9CF0C67A29E4"),
						ProductName = "Phone",
						Quantity = 2,
						UnitPrice = 300,
						TotalPrice = 600
					}
				);
		}
	}
}
