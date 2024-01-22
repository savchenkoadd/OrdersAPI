using System.ComponentModel.DataAnnotations;

namespace Orders.Core.DTO.Order
{
	public class OrderResponse
	{
		public Guid Id { get; set; }

		public string? OrderNumber { get; set; }

		public string? CustomerName { get; set; }

		public DateTime PlacedDate { get; set; }

		public double TotalAmount { get; set; }
	}
}
