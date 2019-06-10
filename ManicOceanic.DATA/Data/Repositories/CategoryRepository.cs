using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManicOceanic.DATA.Data.Repositories
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly MOContext moContext;

    public CategoryRepository(MOContext moContext)
    {
      this.moContext = moContext;
    }

    public async Task<IEnumerable<Category>> ListCategoryAsync()
    {
      return await moContext.Categories.ToListAsync();
    }

    public async Task AddCategoryAsync(Category category)
    {
      await moContext.Categories.AddAsync(category);
    }

    public async Task<Category> FindCategoryByIdAsync(int id)
    {
      return await moContext.Categories.FindAsync(id);
    }

    public void RemoveCategory(Category category)
    {
      moContext.Categories.Remove(category);
    }

    public void UpdateCategory(Category category)
    {
      moContext.Categories.Update(category);
    }
  }
}
