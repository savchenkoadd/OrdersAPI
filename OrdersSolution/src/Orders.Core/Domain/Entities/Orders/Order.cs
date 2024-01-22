using System.ComponentModel.DataAnnotations;

namespace Orders.Core.Domain.Entities.Orders
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(30)]
        public string? OrderNumber { get; set; }

        [StringLength(50)]
        public string? CustomerName { get; set; }

        public DateTime PlacedDate { get; set; }

        public double TotalAmount { get; set; }
    }
}
