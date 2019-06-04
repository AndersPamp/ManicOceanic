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
        public async Task<Shipping> GetShippingByIdAsync(int shippingId)
        {
            var shippingList = await _moContext.Shippings.ToListAsync();
            var shipping =  shippingList.FirstOrDefault(x => x.Id == shippingId);
            return  shipping;
        }
    }
}
