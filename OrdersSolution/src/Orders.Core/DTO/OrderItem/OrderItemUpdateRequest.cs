using System.ComponentModel.DataAnnotations;

namespace Orders.Core.DTO.OrderItem
{
	public class OrderItemUpdateRequest
	{
		[Required]
		public Guid OrderId { get; set; }

		[Required]
		[StringLength(50)]
		public string? ProductName { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int Quantity { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		public double UnitPrice { get; set; }
	}
}
