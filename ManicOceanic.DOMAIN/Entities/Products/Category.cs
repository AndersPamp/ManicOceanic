using System.Collections.Generic;

namespace ManicOceanic.DOMAIN.Entities.Products
{
    public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Category> Categories { get; set; } = new List<Category>();
  }
}
