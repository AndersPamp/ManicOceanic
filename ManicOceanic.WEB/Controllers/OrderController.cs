using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace ManicOceanic.WEB.Controllers
{
    public class OrderController : Controller
    {
        private string strCart = "CartItem";
        private readonly IOrderService _orderService;
        private readonly IShippingService _shippingService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, IShippingService shippingService,ICustomerService customerService)
        {
            _orderService = orderService;
            _shippingService = shippingService;
            _customerService = customerService;
        }

        public IActionResult Order()
        {
            return View("Order");
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderData data)
        {
            var cartList = LoadSession();
            var customerId = data.Id;
            var total = cartList.Sum(x => x.Quantity * x.Product.Price);
            var tax = ((25 * total) / 100);


            var CustomerId1 = Guid.Parse(customerId);
            var OrderDate = DateTime.Now;
            var PaymentType = CheckPayment(data.PaymentOption);
            var Shipping = CheckShipping(data.ShippingOption);
                //Tax = tax,
                //TotalCost = total,
                var OrderNumber = _orderService.GenerateOrderNumberAsync().Result;
                var CustomerName = _customerService.GetCustomerNameByIdAsync(customerId).Result.FirstName;
            


            return View("Order");
        }



        public void SaveToSession(List<CartItem> listOfCarts)
        {
            HttpContext.Session.SetString(strCart, JsonConvert.SerializeObject(listOfCarts));
        }

        public List<CartItem> LoadSession()
        {
            var strList = HttpContext.Session.GetString(strCart);
            var cartList = JsonConvert.DeserializeObject<List<CartItem>>(strList);
            return cartList;
        }

        public EPayment CheckPayment(string payment)
        {
            switch (payment)
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
                    break;
            }

            return EPayment.Invoice;
        }

        public Shipping CheckShipping(string shippingOption)
        {
            switch (shippingOption)
            {
                case "UPS":
                    return  _shippingService.GetShippingByIdAsync(1).Result;
                case "Postnord":
                    return  _shippingService.GetShippingByIdAsync(2).Result;
                case "Schenker":
                    return  _shippingService.GetShippingByIdAsync(3).Result;
            }

            return null;
        }


        public class OrderData
        {
            public string Id { get; set; }
            public string PaymentOption { get; set; }
            public string ShippingOption { get; set; }
        }

    }
}