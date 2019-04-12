using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManicOceanic.DOMAIN.Entities.Sales
{
  public class Shipping
  {
    public int Id { get; set; }
    public EShipping ShippingType { get; set; }
    public decimal Price { get; set; }
  }
}
