using System.ComponentModel.DataAnnotations;

namespace Orders.Core.DTO.Order
{
	public class OrderAddRequest
	{
		[Required]
		[StringLength(50)]
		public string? CustomerName { get; set; }
	}
}
