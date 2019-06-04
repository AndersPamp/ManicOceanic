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
        private string strCart = "Cart";
        private readonly IOrderService orderService;

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

            var newOrder = new Order
            {
                CustomerId = Guid.Parse(customerId),
                OrderDate = DateTime.Now,
                PaymentType = CheckPayment(data.PaymentOption),
                //Shipping = CheckShipping(data.ShippingOption),
                Tax = tax,
                TotalCost = total,
                //OrderNumber = 1,
                //CustomerName = "wade",
            };


            return View("Order");
        }



        public void SaveToSession(List<Cart> listOfCarts)
        {
            HttpContext.Session.SetString(strCart, JsonConvert.SerializeObject(listOfCarts));
        }

        public List<Cart> LoadSession()
        {
            var strList = HttpContext.Session.GetString(strCart);
            var cartList = JsonConvert.DeserializeObject<List<Cart>>(strList);
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

        private Shipping CheckShipping(string shippingOption)
        {
            var shipping = new Shipping();
            switch (shippingOption)
            {
                case "UPS":
                    shipping.ShippingType = EShipping.Ups;
                    shipping.Price = 165;
                    break;
                case "Postnord":
                    shipping.ShippingType = EShipping.Postnord;
                    shipping.Price = 49;
                    break;
                case "Schenker":
                    shipping.ShippingType = EShipping.Schenker;
                    shipping.Price = 145;
                    break;
            }
            return shipping;
        }

        public class OrderData
        {
            public string Id { get; set; }
            public string PaymentOption { get; set; }
            public string ShippingOption { get; set; }
        }

    }
}