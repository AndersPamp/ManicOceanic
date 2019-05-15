using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly MOContext _dbContext;

        public ProductController (MOContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult SaltWaterFish()
        {
            var productsList = _dbContext.Products.Where(x => x.CategoryId == 1).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }
            
            return View(productsList);
        }

        public IActionResult FreshWaterFish()
        {
            var productsList = _dbContext.Products.Where(x => x.CategoryId == 2).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }

            return View(productsList);
        }

        public IActionResult FishFood()
        {
            var productsList = _dbContext.Products.Where(x => x.CategoryId == 3).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }

            return View(productsList);
        }

        public IActionResult Aquarium()
        {
            var productsList = _dbContext.Products.Where(x => x.CategoryId == 4).ToList();

            if (productsList == null)
            {
                throw new Exception("Products not found");
            }

            return View(productsList);
        }
        
    }
}