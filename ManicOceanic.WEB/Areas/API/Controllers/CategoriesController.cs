using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Services.Interfaces;
using ManicOceanic.WEB.Dto;
using ManicOceanic.WEB.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategoriesAsync()
        {
            return Ok(await categoryService.ListCategoriesAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> GetCategoryByIdAsync(int id)
        {
            return await categoryService.GetCategoryByCategoryIdAsync(id);
        }

        [HttpPost]

        public async Task<ActionResult<Category>> AddCategoryAsync([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = mapper.Map<CategoryDto, Category>(categoryDto);
            var result = await categoryService.CreateCategoryAsync(category
            );
            return Created($"/api/categories/{result.Id}", result);
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<ActionResult<Category>> DeleteCategoryAsync(int id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }

        [HttpPut]
 
        public async Task<ActionResult<Category>> UpdateCategoryAsync([FromBody] CategoryDto categoryDto
        )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = mapper.Map<CategoryDto, Category>(categoryDto);

            var result = await categoryService.UpdateCategoryAsync(category);
            return Accepted($"api/categories/{result.Id}", result);
        }

    }
}

