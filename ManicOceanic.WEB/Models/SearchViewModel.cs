using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.WEB.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Product> SearchResult { get; set; }
    }
}
