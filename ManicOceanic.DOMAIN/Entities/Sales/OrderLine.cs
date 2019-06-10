using System;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.DOMAIN.Entities.Sales
{
    public class OrderLine
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Subtotal { get; set; }
    }
}
