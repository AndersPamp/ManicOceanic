using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.DOMAIN.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListCategoriesAsync();
        Task<Category> GetCategoryByCategoryIdAsync(int id);
        Task<Category> DeleteCategoryAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
    }
}
