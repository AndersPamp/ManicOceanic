using ManicOceanic.DOMAIN.Entities.Products;
using System.Collections.Generic;

namespace ManicOceanic.WEB.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
