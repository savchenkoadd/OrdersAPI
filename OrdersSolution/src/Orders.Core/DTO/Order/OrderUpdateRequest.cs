using System.ComponentModel.DataAnnotations;

namespace Orders.Core.DTO.Order
{
	public class OrderUpdateRequest
	{
		[Required]
		[StringLength(50)]
		public string? CustomerName { get; set; }
	}
}
