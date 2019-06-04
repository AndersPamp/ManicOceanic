using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        void DeleteOrder(Order order);

        void UpdateOrder(Order order);
        Task<Order> GetOrderByOrderNumberAsync(int orderNumber);
        Task<int> GenerateOrderNumberAsync();
    }
}
