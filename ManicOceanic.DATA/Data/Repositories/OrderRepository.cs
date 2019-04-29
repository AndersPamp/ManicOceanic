using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManicOceanic.DATA.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MOContext moContext;


        public OrderRepository(MOContext moContext)
        {
            this.moContext = moContext;

        }


        public void CreateOrder(Order order)
        {
            moContext.Orders.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            moContext.Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            moContext.Orders.Update(order);
        }

        public async Task<Order> GetOrderByOrderNumberAsync(int orderNumber)
        {
            return await moContext.Orders.FirstOrDefaultAsync(o => o.OrderNumber == orderNumber);
        }
    }
}
