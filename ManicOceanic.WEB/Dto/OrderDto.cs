using System;
using System.ComponentModel.DataAnnotations;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.WEB.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public EPayment PaymentType { get; set; }
        [Required]
        public Shipping Shipping { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
