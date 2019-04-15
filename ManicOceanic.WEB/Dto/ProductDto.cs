using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using System;

namespace ManicOceanic.WEB.Dto
{
    public class ProductDto
  {
    public Guid Id { get; set; }
    public int ProductNumber { get; set; }
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
