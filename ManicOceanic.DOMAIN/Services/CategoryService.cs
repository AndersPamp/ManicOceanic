using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services.Interfaces;

namespace ManicOceanic.DOMAIN.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Category>> ListCategoriesAsync()
        {
            return await categoryRepository.ListCategoryAsync();
        }

        public async Task<Category> GetCategoryByCategoryIdAsync(int id)
        {
            return await
                categoryRepository.FindCategoryByIdAsync(id);
        }


        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var category = await categoryRepository.FindCategoryByIdAsync(id);
            categoryRepository.RemoveCategory(category);
            await unitOfWork.SaveChangesAsync();
            return category;
        }

        
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await categoryRepository.AddCategoryAsync(category); //ev ska vara await 
            await unitOfWork.SaveChangesAsync();
            return category;
        }

      
        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            categoryRepository.UpdateCategory(category);
            await unitOfWork.SaveChangesAsync();
            return category;

        }
    }
}
