using System.ComponentModel.DataAnnotations;

namespace Orders.Core.DTO.Order
{
	public class OrderUpdateRequest
	{
		[Required]
		public Guid OrderId { get; set; }

		[Required]
		[StringLength(50)]
		public string? CustomerName { get; set; }
	}
}
