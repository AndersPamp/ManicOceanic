using ManicOceanic.DATA.Data;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ManicOceanic.WEB.Controllers
{
    public class ProductCartController : Controller  
    {
        private readonly MOContext _dbContext;
        private string strCart = "Cart";

        public ProductCartController(MOContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
            {
                return View();
            }

            var cartList = LoadSession();

            return View(cartList);
        }

        public IActionResult OrderNow(Guid? id)
        {
            if(id==null)
            {

                return BadRequest();
            }

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
            {
                List<Cart> IsCart = new List<Cart>
                {
                    new Cart(_dbContext.Products.Find(id),1)
                };

                HttpContext.Session.SetString(strCart, JsonConvert.SerializeObject(IsCart));
            }
            else
            {
                var cartList = LoadSession();

                var chosenProduct = cartList.FirstOrDefault(x => x.Product.Id == id);

                if (chosenProduct != null)
                {
                    cartList.FirstOrDefault(x => x.Product.Id == id).Quantity++;

                    SaveToSession(cartList);

                    return View("Index", cartList);
                }
                cartList.Add(new Cart(_dbContext.Products.Find(id),1));

                SaveToSession(cartList);
            }

             var cartList1 = LoadSession();

            return View("Index",cartList1);
        }

        public IActionResult DeleteItem(Guid? id)
        {

            var cartList = LoadSession();

            if (id == null)
            {
                return View("Index",cartList);
            }

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
            {
                return View("Index");
            }
            var chosenProduct = cartList.FirstOrDefault(x => x.Product.Id == id);

            if (chosenProduct != null)
            {
                cartList.Remove(chosenProduct);

                SaveToSession(cartList);

                return View("Index", cartList);
            }

            return View("Index",cartList);
        }

        public IActionResult ChoseShipping(string shippingName)
        {

            return View("Index");
        }
        public IActionResult ChangeQuantity(int quantity)
        {

            return View("Index");
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