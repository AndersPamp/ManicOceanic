using System;
using System.Collections.Generic;
using System.Linq;
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
        public void CreateOrderLine(OrderLine orderLine)
        {
            moContext.OrderLines.Add(orderLine);
            try
            {
                moContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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

        public async Task<int> GenerateOrderNumberAsync()
        {
            var number = 101;


            if (moContext.Orders.Count() == 0)
            {
                return number;
            }
            else
            {
                var orderNbr = moContext.Orders.Max(c => c.OrderNumber) + 1;
                return orderNbr;
            }
        }
        public EPayment GetPaymentMethod(string paymentOption)
        {
            switch (paymentOption)
            {
                case "Klarna":
                    return EPayment.Klarna;
                case "Credit Card":
                    return EPayment.CreditCard;
                case "PayPal":
                    return EPayment.PayPal;
                case "Invoice":
                    return EPayment.Invoice;
                default:
                    return EPayment.Invoice;
            }
        }
        public async Task<IEnumerable<Order>> ListOrderAsync(Guid userId)
        {
            return await moContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<OrderLine>> ListOrderLinesAsync(Guid orderId)
        {
            return await moContext.OrderLines.Where(x => x.OrderId == orderId).Include(p=>p.Product).ToListAsync();
        }

        public async Task<IEnumerable<Order>> ListOrdersAdmin()
        {
            return await moContext.Orders.ToListAsync();
        }
    }
}
