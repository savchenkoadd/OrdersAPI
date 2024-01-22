using System.ComponentModel.DataAnnotations;

namespace Orders.Core.Entities.Orders
{
	public class Order
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[StringLength(30)]
		public string? OrderNumber { get; set; }

		[Required]
		[StringLength(50)]
		public string? CustomerName { get; set; }

		[Required]
		public DateTime PlacedDate { get; set; }

		[Range(0, double.MaxValue)]
		public double TotalAmount { get; set; }
	}
}
