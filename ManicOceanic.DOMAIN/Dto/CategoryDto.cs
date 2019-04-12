using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManicOceanic.DOMAIN.Dto
{
  public class CategoryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Category> Categories { get; set; }
  }
}
