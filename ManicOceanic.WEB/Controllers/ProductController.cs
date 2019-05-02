using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult SaltWaterFish()
        {
            return View();
        }

        public IActionResult FreshWaterFish()
        {
            return View();
        }

        public IActionResult FishFood()
        {
            return View();
        }

        public IActionResult Aquarium()
        {
            return View();
        }
    }
}