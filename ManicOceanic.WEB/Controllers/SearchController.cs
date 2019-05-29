using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class SearchController : Controller
    {
        private readonly MOContext moContext;
        private readonly IProductService productService;

        public SearchController(MOContext moContext, IProductService productService)
        {
            this.moContext = moContext;
            this.productService = productService;
        }


        public async Task<IActionResult> SearchProduct(string searchWord)
        {
            var productList = await productService.GetProductBySearchAsync(searchWord);

            if (productList == null)
            {
                throw new Exception("No product found");
            }
            var viewModel = new SearchViewModel();

            viewModel.SearchResult = productList;

            return View(viewModel);
        }
    }
}


