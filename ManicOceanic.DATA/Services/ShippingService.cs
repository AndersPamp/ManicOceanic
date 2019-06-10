using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services.Interfaces;

namespace ManicOceanic.DATA.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IShippingRepository shippingRepository;
        private readonly IUnitOfWork unitOfWork;

        public ShippingService(IShippingRepository shippingRepository, IUnitOfWork unitOfWork)
        {
            this.shippingRepository = shippingRepository;
            this.unitOfWork = unitOfWork;
        }
        public int GetShippingPrice(int shippingId)
        {
            return shippingRepository.GetShippingPrice(shippingId);
        }

        public int GetShippingId(string shippingOption)
        {
            return shippingRepository.GetShippingId(shippingOption);
        }
    }
}
