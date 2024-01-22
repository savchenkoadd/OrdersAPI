using Microsoft.EntityFrameworkCore;
using Orders.Core.Domain.RepositoryContracts;
using Orders.Core.ServiceContracts;
using Orders.Core.Services;
using Orders.Infrastructure.Db;
using Orders.Infrastructure.Repositories;
using Orders.WebAPI.Middleware;

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
			builder.Services.AddScoped<IOrderItemService, OrderItemService>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}