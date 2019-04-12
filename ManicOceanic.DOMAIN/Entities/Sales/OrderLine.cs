using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;
using Microsoft.AspNetCore.ResponseCompression;

namespace ManicOceanic.DOMAIN.Entities.Sales
{
  public class OrderLine
  {
    public int Id { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public decimal UnitCost { get; set; }
    public decimal Subtotal { get; set; }
  }
}
