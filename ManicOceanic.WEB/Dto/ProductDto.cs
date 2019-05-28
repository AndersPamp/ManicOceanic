using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Entities.Products;
using System;
using System.ComponentModel.DataAnnotations;

namespace ManicOceanic.WEB.Dto
{
    public class ProductDto
  {
    public Guid Id { get; set; }
    public int ProductNumber { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "The {0} cannot have more than {1} characters.")]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [DataType(DataType.ImageUrl)]
    public string ImageUrl { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    [StringLength(300)]
    public string Description { get; set; }
    [Required]
    public EUnitOfMeasure UnitOfMeasure { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
  }
}
