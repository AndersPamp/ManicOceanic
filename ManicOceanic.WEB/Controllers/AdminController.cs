using ManicOceanic.DOMAIN.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using AutoMapper;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;
using ManicOceanic.DOMAIN.Entities.Products;
using System;
using ManicOceanic.DOMAIN.Repositories.Interfaces;

namespace ManicOceanic.WEB.Controllers
{
  public class AdminController : Controller
  {
    private readonly IProductService productService;
    private readonly ICategoryService categoryService;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public AdminController(ICategoryService categoryService, IProductService productService, IMapper mapper, IUnitOfWork unitOfWork)
    {
      this.categoryService = categoryService;
      this.productService = productService;
      this.mapper = mapper;
      this.unitOfWork = unitOfWork;
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
      return View();
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

      return View(product);
    }
  }
}