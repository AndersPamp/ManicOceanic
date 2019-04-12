using System.Collections.Generic;

namespace ManicOceanic.DOMAIN.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
