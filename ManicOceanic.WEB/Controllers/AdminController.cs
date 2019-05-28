using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using AutoMapper;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public AdminController(ICategoryService categoryService, IProductService productService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.mapper = mapper;
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

        public async Task<IActionResult> ProductDelete(int productNumber)
        {
            var product = await productService.DeleteProductAsync(productNumber);
           
            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.ListCategoriesAsync();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = mapper.Map<ProductDto, Product>(productDto);
            var result = await productService.CreateProductAsync(product);
            return View();
        }
    }
}