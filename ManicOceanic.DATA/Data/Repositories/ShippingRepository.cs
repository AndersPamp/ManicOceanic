using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManicOceanic.DATA.Data.Repositories
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly MOContext _moContext;
        public ShippingRepository(MOContext moContext)
        {
            this._moContext = moContext;
        }
        public Task<Shipping> GetShippingByIdAsync(int shippingId)
        {
            var shippings = _moContext.Shippings.ToList();
            var shipping = shippings.FirstOrDefault(x => x.Id == shippingId);

            return shipping;

        }
    }
}
