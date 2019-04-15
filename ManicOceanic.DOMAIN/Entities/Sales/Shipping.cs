namespace ManicOceanic.DOMAIN.Entities.Sales
{
    public class Shipping
  {
    public int Id { get; set; }
    public EShipping ShippingType { get; set; }
    public decimal Price { get; set; }
  }
}
