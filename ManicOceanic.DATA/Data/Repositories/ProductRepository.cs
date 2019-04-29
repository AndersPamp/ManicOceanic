using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Data;
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
    }
}
