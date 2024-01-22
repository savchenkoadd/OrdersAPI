using System.ComponentModel.DataAnnotations;

namespace Orders.Core.Entities.Orders
{
	public class OrderItem
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public Guid OrderId { get; set; }

		[Required]
		[StringLength(50)]
		public string? ProductName { get; set; }

		[Range(0, int.MaxValue)]
		public int Quantity { get; set; }

		[Range(0, double.MaxValue)]
		public double UnitPrice { get; set; }

		public double TotalPrice { get; set; }
	}
}
