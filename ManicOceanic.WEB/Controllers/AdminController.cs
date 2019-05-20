using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ManicOceanic.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public AdminController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Product()
        {
            var products = await productService.ListProductsAsync();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.ListCategoriesAsync();

            ViewData["CategoryId"] = new SelectList(categories);

            return View();
        }
    }
}