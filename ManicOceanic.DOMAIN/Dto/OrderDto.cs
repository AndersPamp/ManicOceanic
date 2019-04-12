using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManicOceanic.DOMAIN.Dto
{
  public class OrderDto
  {
    public Guid CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
  }
}
