using System;

namespace ManicOceanic.WEB.Dto
{
    public class OrderDto
  {
    public Guid CustomerId { get; set; }
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
  }
}
