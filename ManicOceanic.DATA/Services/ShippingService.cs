using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Services.Interfaces;

namespace ManicOceanic.DATA.Services
{
    public class ShippingService : IShippingService
    {

        public Task<Shipping> GetShippingByIdAsync (int shippingId)
        {
            return null;
        }
    }
}
