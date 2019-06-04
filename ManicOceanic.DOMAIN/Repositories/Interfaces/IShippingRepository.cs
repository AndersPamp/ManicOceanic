using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface IShippingRepository
    {
        Task<Shipping> GetShippingByIdAsync(int shippingId);
    }
}
