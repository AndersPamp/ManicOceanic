using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListCategoryAsync();
        Task AddCategoryAsync(Category category);

        Task<Category> FindCategoryByIdAsync(int id);

        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
    }
}
