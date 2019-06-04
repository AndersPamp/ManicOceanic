using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManicOceanic.DATA.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MOContext moContext;

        public ProductRepository(MOContext moContext)
        {
            this.moContext = moContext;
        }

        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            return await moContext.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetProductByProductNumberAsync(int productNumber)
        {
            return await moContext.Products.FirstOrDefaultAsync(p => p.ProductNumber == productNumber);
        }

        public void DeleteProduct(Product product)
        {
            moContext.Products.Remove(product);
        }

        public void CreateProduct(Product product)
        {
            moContext.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            moContext.Products.Update(product);
        }


        public async Task<Product> GetProductByCategoryIdAsync(int categoryId)
        {
            var allProducts = await moContext.Products.ToListAsync();
            var onlyOneCategory = new List<Product>();

            foreach (var product in allProducts)
            {
                if (product.CategoryId == categoryId)
                {
                    onlyOneCategory.Add(product);

                }
            }

            return onlyOneCategory.OrderBy(r => Guid.NewGuid()).Take(1).First();
        }

        public async Task<Product> GetRandomProductAsync()
        {   
          
            return moContext.Products.OrderBy(r => Guid.NewGuid()).Take(1).First();
        }

        public async Task<IEnumerable<Product>> GetProductBySearchAsync(string searchWord)
        {
            return await moContext.Products.Where(x => x.Name.Contains(searchWord) || searchWord == null)
                .ToListAsync();

        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await moContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
    }
}
