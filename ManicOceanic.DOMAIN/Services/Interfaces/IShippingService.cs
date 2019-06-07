using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Services.Interfaces
{
    public interface IShippingService
    {
        int GetShippingPrice(int shippingId);
        int GetShippingId(string shippingOption);
    }
}
