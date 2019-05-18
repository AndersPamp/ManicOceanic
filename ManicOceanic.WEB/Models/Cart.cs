using ManicOceanic.DOMAIN.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManicOceanic.WEB.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Cart(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
