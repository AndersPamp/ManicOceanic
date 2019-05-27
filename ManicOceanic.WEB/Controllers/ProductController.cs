using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly MOContext moContext;
        private readonly IProductService productService;

        public ProductController (MOContext moContext, IProductService productService)
        {
            this.moContext = moContext;
            this.productService = productService;
        }

        public IActionResult SaltWaterFish()
        {
            var productsList = moContext.Products.Where(x => x.CategoryId == 1).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }
            
            return View(productsList);
        }

        public IActionResult FreshWaterFish()
        {
            var productsList = moContext.Products.Where(x => x.CategoryId == 2).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }

            return View(productsList);
        }

        public IActionResult FishFood()
        {
            var productsList = moContext.Products.Where(x => x.CategoryId == 3).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }

            return View(productsList);
        }

        public IActionResult Aquarium()
        {
            var productsList = moContext.Products.Where(x => x.CategoryId == 4).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }

            return View(productsList);
        }

        public async Task<IActionResult> ShowDetail(int productNumber)
        {
            var product = await productService.GetProductByProductNumberAsync(productNumber);
           

            if (product == null)
            {
                throw new Exception("Oooppps something went wrong");
            }
            var viewModel = new ProductDetailViewModel
            {
                Product = product
            };

            return View(viewModel);
        }

    }
}