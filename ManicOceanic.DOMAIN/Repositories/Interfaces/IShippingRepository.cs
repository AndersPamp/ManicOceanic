using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface IShippingRepository
    {
        int GetShippingPrice(int shippingId);
        int GetShippingId(string shippingOption);
    }
}
