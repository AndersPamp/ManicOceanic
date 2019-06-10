using AutoMapper;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManicOceanic.WEB.Areas.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AdminController : ControllerBase
  {
    private readonly IProductService productService;
    private readonly IMapper mapper;

    public AdminController(IProductService productService, IMapper mapper)
    {
      this.productService = productService;
      this.mapper = mapper;

    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProductAsync([FromBody] ProductDto productDto)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState.GetErrorMessages());

      var product = mapper.Map<ProductDto, Product>(productDto);
      var result = await productService.CreateProductAsync(product);
      return Created($"/api/products/{result.ProductNumber}", result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> DeleteProductAsync(int id)
    {
      var result = await productService.DeleteProductAsync(id);
      return Ok(result);
    }
  }
}