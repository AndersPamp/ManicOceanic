using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ManicOceanic.WEB.Controllers
{
    public class OrderController : Controller
    {
        private string strCart = "Cart";

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult CreateOrder(string id)
        {
            var cartList = LoadSession();
            var newOrder = new Order();
            var userId = id;

            return Redirect("/Order/Order");
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
    }
}