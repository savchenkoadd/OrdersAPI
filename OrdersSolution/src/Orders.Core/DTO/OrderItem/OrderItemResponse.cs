using System.ComponentModel.DataAnnotations;

namespace Orders.Core.DTO.OrderItem
{
	internal class OrderItemResponse
	{
		public Guid Id { get; set; }

		public Guid OrderId { get; set; }

		public string? ProductName { get; set; }

		public int Quantity { get; set; }

		public double UnitPrice { get; set; }

		public double TotalPrice { get; set; }
	}
}
