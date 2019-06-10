using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services.Interfaces;

namespace ManicOceanic.DOMAIN.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            orderRepository.CreateOrder(order);
            await unitOfWork.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrderAsync(int orderNumber)
        {
            var existingOrder = await orderRepository.GetOrderByOrderNumberAsync(orderNumber);
            orderRepository.DeleteOrder(existingOrder);
            await unitOfWork.SaveChangesAsync();
            return existingOrder;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {

            orderRepository.UpdateOrder(order);
            await unitOfWork.SaveChangesAsync();
            return order;
        }

        public async Task<int> GenerateOrderNumberAsync()
        {
            return await orderRepository.GenerateOrderNumberAsync();
        }
        public EPayment GetPaymentMethod(string paymentOption)
        {
            return orderRepository.GetPaymentMethod(paymentOption);
        }

        public async Task<OrderLine> CreateOrderLinesAsync(OrderLine orderLine)
        {
            orderRepository.CreateOrderLine(orderLine);
            await unitOfWork.SaveChangesAsync();
            return orderLine;

        }
    }
}
