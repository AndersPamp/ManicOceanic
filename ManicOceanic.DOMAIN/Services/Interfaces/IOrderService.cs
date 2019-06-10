using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;

namespace ManicOceanic.DOMAIN.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);

        Task<Order> DeleteOrderAsync(int orderNumber);

        Task<Order> UpdateOrderAsync(Order order);
        Task<int> GenerateOrderNumberAsync();
        EPayment GetPaymentMethod(string paymentOption);

        Task<OrderLine> CreateOrderLinesAsync(OrderLine orderLine);
    }
}
