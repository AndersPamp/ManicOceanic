using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManicOceanic.DOMAIN.Dto
{
  public class ProductDto
  {
    public Guid Id { get; set; }
    public Int ProductNumber { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
    public EUnitOfMeasure UnitOfMeasure { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  }
}
