using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        void UpdateCustomerProfile(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<Customer> GetCustomerBySocialSecurityNumber(string socialSecurityNumber);
    }
}
