using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Services.Interfaces
{
    public interface IShippingService
    {
        Task<Shipping> GetShippingByIdAsync(int shippingId);
    }
}
