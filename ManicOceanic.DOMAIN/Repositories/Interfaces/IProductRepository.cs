using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.DOMAIN.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListProductsAsync();
        Task<Product> GetProductByProductNumberAsync(int productNumber);
        void DeleteProduct(Product product);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        Task<Product> GetProductByCategoryIdAsync(int categoryId);
        Task<Product> GetRandomProductAsync();
        Task<IEnumerable<Product>> GetProductBySearchAsync(string searchWord);
        Task<Product> GetProductByIdAsync(Guid id);
    }
}
