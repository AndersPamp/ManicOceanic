using ManicOceanic.DATA.Data;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ManicOceanic.DOMAIN.Entities.Sales;
using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ManicOceanic.WEB.Controllers
{
  public class ProductCartController : Controller
  {
    private readonly MOContext _dbContext;
    private string strCart = "Cart";

    public ProductCartController(MOContext dbContext)
    {
        private readonly IProductService _productService;
        private string strCart = "CartItem";

        public ProductCartController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
            {
                return View();
            }
            var cartList = LoadSession();
            if (cartList.Count <=0 )
            {
                return View(); 
            }

    public IActionResult OrderNow(Guid? id)
    {
      if (id == null)
      {

        return BadRequest();
      }

      if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
      {
        var newProduct = _dbContext.Products.Find(id);

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(strCart)))
            {
                var newProduct = _productService.GetProductByIdAsync(id).Result;
                
                if (newProduct.Stock>0)
                {
                    List<CartItem> isCart = new List<CartItem>
                    {
                        new CartItem(newProduct,1)
                    };
                    HttpContext.Session.SetString(strCart, JsonConvert.SerializeObject(isCart));
                }
            }
            else
            {
                var cartList = LoadSession();

        var chosenProduct = cartList.FirstOrDefault(x => x.Product.Id == id);


        if (chosenProduct != null)
        {
          cartList.FirstOrDefault(x => x.Product.Id == id).Quantity++;

                    return Redirect("/ProductCart/index");
                }
                else
                {
                    var product = _productService.GetProductByIdAsync(id).Result;

                    if (product.Stock > 0)
                    {
                        cartList.Add(new CartItem(product, 1));

          var stock = product.Stock;
          if (stock > 0)
          {
            cartList.Add(new Cart(product, 1));

            return Redirect("/ProductCart/index");
        }
      }

      return Redirect("/ProductCart/index");
    }

    public IActionResult DeleteItem(Guid? id)
    {

      var cartList = LoadSession();

      if (id == null)
      {
        return View("Index", cartList);
      }

            if (chosenProduct != null)
            {
                if (cartList.Count == 1)
                {
                    cartList.Remove(chosenProduct);
                    SaveToSession(cartList);
                    return View("Index");
                }
                cartList.Remove(chosenProduct);

      if (chosenProduct != null)
      {
        cartList.Remove(chosenProduct);

        SaveToSession(cartList);

            return View("Index",cartList);
        }
        
        [HttpPost]
        public IActionResult ChangeQuantity([FromBody]Data data)           
        {
            var quantity = data.Quantity;
            var productId = data.Id;

    public IActionResult ChoseShipping(string shippingName)
    {
      var shippingChoice = new Shipping();

      return View("Index");
    }

    [HttpPost]
    public IActionResult ChangeQuantity([FromBody]Data data)
    {
      var quantity = data.Quantity;
      var productId = data.Id;

            SaveToSession(cartList);
            return Redirect("/ProductCart/index");
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
    }

    public List<Cart> LoadSession()
    {
      var strList = HttpContext.Session.GetString(strCart);
      var cartList = JsonConvert.DeserializeObject<List<Cart>>(strList);
      return cartList;
    }
  }

  public class Data
  {
    public Guid Id { get; set; }
    public int Quantity { get; set; }
  }
}