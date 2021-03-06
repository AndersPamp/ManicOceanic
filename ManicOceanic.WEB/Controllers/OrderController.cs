﻿using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Order(string id)
        {
            if (id == null)
            {
                return Redirect("/ProductCart/index");
            }
            
            var listOfOrders = _orderService.ListOrderAsync(Guid.Parse(id)).Result;
            if (listOfOrders != null)
            {
                return View("Order", listOfOrders);
            }

            return View("Order");
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderData data)
        {
            var cartList = LoadSession();
            var customerId = data.Id;
            var orderDate = DateTime.Now;
            var paymentType = _orderService.GetPaymentMethod(data.PaymentOption);
            var shippingId = _shippingService.GetShippingId(data.ShippingOption);
            var total = cartList.Sum(x => x.Quantity * x.Product.Price);
            var tax = ((25 * total) / 100);
            var orderNumber = _orderService.GenerateOrderNumberAsync().Result;
            var customerName = _customerService.GetCustomerNameByIdAsync(customerId).Result.FirstName;

            var newOrder = _orderService.CreateOrderAsync(new Order
            {
                CustomerId = Guid.Parse(customerId),
                CustomerName = customerName,
                OrderDate = orderDate,
                OrderNumber = orderNumber,
                PaymentType = paymentType,
                ShippingId = shippingId,
                Tax = tax,
                TotalCost = total + _shippingService.GetShippingPrice(shippingId)
             });

            var orderId = newOrder.Result.Id;

            for (int i = 0; i < cartList.Count; i++)
            {
                var newOrderLine = _orderService.CreateOrderLines(new OrderLine
                {
                    ProductId = cartList[i].Product.Id,
                    Quantity = cartList[i].Quantity,
                    UnitCost = cartList[i].Product.Price,
                    Subtotal = total,
                    OrderId = orderId
                });
            }
            HttpContext.Session.Clear();
            return View("CreateOrder",newOrder.Result);
        }

        public IActionResult OrderCreated()
        {
            var orderList = _orderService.ListOrdersAdmin();
            var order = orderList.Result.Last();
            return View("CreateOrder", order);
        }

        public IActionResult ListMyOrders(string userId)
        {
            if (userId == null)
            {
                return Redirect("/ProductCart/index");
            }
            var listOfOrders = _orderService.ListOrderAsync(Guid.Parse(userId)).Result;

            return View("Order", listOfOrders);
        }

        public IActionResult ListOrderLines(Guid id)
        {
            if (id==null)
            {
                return Redirect("/ProductCart/index");
            }

            var listOfOrderLines = _orderService.ListOrderLinesAsync(id).Result;

            return View("Details",listOfOrderLines);
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
        public class OrderData
        {
            public string Id { get; set; }
            public string PaymentOption { get; set; }
            public string ShippingOption { get; set; }
        }
    }
}