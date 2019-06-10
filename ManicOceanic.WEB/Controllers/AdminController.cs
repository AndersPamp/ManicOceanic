using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using AutoMapper;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ManicOceanic.WEB.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrderService orderService;

        public AdminController(ICategoryService categoryService, IProductService productService, IMapper mapper, IUnitOfWork unitOfWork,IOrderService orderService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList()
        {
            var products = await productService.ListProductsAsync();

            return View(products);
        }

        public async Task<IActionResult> ProductDelete(int productNumber)
        {
            var product = await productService.DeleteProductAsync(productNumber);

            return View(product);
        }

        public async Task<IActionResult> CreateProduct()
        {
            var categories = await categoryService.ListCategoriesAsync();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var product = mapper.Map<ProductDto, Product>(productDto);
            var result = await productService.CreateProductAsync(product);

            return Redirect("/Admin/ProductList");
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = await productService.GetProductByProductNumberAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(await categoryService.ListCategoriesAsync(), "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(int ProductNumber, Product product)
        {
            if (ProductNumber != product.ProductNumber)
            {
                return NotFound();
            }

            await productService.UpdateProductAsync(product);

            ViewData["CategoryId"] = new SelectList(await categoryService.ListCategoriesAsync(), "Id", "Name", product.CategoryId);

            return Redirect("/Admin/ProductList");
        }



        // ************ Category *******************

        public async Task<IActionResult> Category()
        {
            var categories = await categoryService.ListCategoriesAsync();

            return View(categories);
        }

        public async Task<IActionResult> CategoryDelete(int id)
        {
            var category = await categoryService.DeleteCategoryAsync(id);

            return View(category);
        }


        public async Task<IActionResult> CategoryCreate()
        {
            var categories = await categoryService.ListCategoriesAsync();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<CategoryDto, Category>(categoryDto);
            var result = await categoryService.CreateCategoryAsync(category);

            return Redirect("/Admin/Category");
        }

        public async Task<IActionResult> CategoryEdit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var category = await categoryService.GetCategoryByCategoryIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(await categoryService.ListCategoriesAsync(), "Id", "Name", category.CategoryId);

            return View(category);
        }


        [HttpPost]
        public async Task<IActionResult> CategoryEdit(Category category)
        {
            await categoryService.UpdateCategoryAsync(category);

            ViewData["CategoryId"] = new SelectList(await categoryService.ListCategoriesAsync(), "Id", "Name", category.CategoryId);

            return Redirect("/Admin/Category");
        }

        public async Task<IActionResult> OrderList()
        {
            var orders = await orderService.ListOrdersAdmin();

            return View("Orders",orders);
        }

    }
}