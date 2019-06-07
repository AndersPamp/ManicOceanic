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

        public int GetShippingPrice(int shippingId)
        {
            switch (shippingId)
            {
                case 3:
                    return  145;
                case 4:
                    return 49;
                case 5:
                    return 169;
                default:
                    return 0;
            }
        }

        public int GetShippingId(string shippingOption)
        {
            switch (shippingOption)
            {
                case "UPS":
                    return 3;
                case "Postnord":
                    return 4;
                case "Schenker":
                    return 5;
                default:
                    return 4;
            }
        }
    }
}
