using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManicOceanic.DATA.Data.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly MOContext moContext;

        public CustomerRepository(MOContext moContext)
        {
            this.moContext = moContext;
        }

        public void CreateCustomer(Customer customer)
        {
            moContext.Customers.Add(customer);
        }


        public void UpdateCustomerProfile(Customer customer)
        {
            moContext.Customers.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            moContext.Customers.Remove(customer);
        }

        public async Task<Customer> GetCustomerBySocialSecurityNumber(string socialSecurityNumber)
        {
            return await moContext.Customers.FirstOrDefaultAsync(s => s.SocialSecurityNumber == socialSecurityNumber);
        }
    }
}
