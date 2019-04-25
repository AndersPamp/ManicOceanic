using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities;

namespace ManicOceanic.DOMAIN.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerProfileAsync(string socialSecurityNumber, Customer customer);
        Task<Customer> DeleteCustomerAsync(string socialSecurityNumber);
    }
}
