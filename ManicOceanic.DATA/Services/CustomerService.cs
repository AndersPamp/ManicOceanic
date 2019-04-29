using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services.Interfaces;

namespace ManicOceanic.DOMAIN.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customerRepository.CreateCustomer(customer);
            await unitOfWork.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerProfileAsync(Customer customer)
        {

            customerRepository.UpdateCustomerProfile(customer);
            await unitOfWork.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(string socialSecurityNumber)
        {
            var existingCustomer = await customerRepository.GetCustomerBySocialSecurityNumber(socialSecurityNumber);
            customerRepository.DeleteCustomer(existingCustomer);
            await unitOfWork.SaveChangesAsync();
            return existingCustomer;
        }
    }
}
