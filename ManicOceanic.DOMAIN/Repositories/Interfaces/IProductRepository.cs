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
    }
}
