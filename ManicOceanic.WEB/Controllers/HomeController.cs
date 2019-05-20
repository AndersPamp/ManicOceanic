using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ManicOceanic.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace ManicOceanic.WEB.Controllers
{
  public class HomeController : Controller
  {
      private readonly IProductService productService;
      private readonly MOContext moContext;
      

      public HomeController(IProductService productService, MOContext moContext)
      {
          this.productService = productService;
          this.moContext = moContext;
      }

    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeViewModel();

            //viewModel.HeroProduct = await productService.GetRandomProductAsync();
            viewModel.Fish = await productService.GetProductByCategoryIdAsync(1);

            viewModel.FishFood = await productService.GetProductByCategoryIdAsync(3);
            viewModel.Aquarium = await productService.GetProductByCategoryIdAsync(4);

            return View(viewModel);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
