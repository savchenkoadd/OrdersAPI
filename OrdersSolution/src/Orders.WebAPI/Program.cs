using Microsoft.EntityFrameworkCore;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.ServiceContracts;
using Orders.Core.Services;
using Orders.Infrastructure.Db;
using Orders.Infrastructure.Repositories;

namespace Orders.WebAPI
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
			});

			builder.Services.AddScoped<IOrderRepository, OrderRepository>();
			builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
			builder.Services.AddScoped<IOrderService, OrderService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}