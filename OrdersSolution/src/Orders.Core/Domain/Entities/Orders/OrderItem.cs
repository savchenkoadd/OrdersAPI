using System.ComponentModel.DataAnnotations;

namespace Orders.Core.Entities.Orders
{
	public class OrderItem
	{
		[Key]
		public Guid Id { get; set; }

		public Guid OrderId { get; set; }

		public string? ProductName { get; set; }

		public int Quantity { get; set; }

		public double UnitPrice { get; set; }

		public double TotalPrice { get; set; }
	}
}
