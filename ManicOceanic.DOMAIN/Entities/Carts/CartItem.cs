namespace ManicOceanic.DOMAIN.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
