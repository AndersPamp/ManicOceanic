using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;
using ManicOceanic.DOMAIN.Repositories.Interfaces;
using ManicOceanic.DOMAIN.Services.Interfaces;

namespace ManicOceanic.DOMAIN.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;


        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;

        }

        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            return await productRepository.ListProductsAsync();
        }



        public async Task<Product> GetProductByProductNumberAsync(int productNumber)
        {
            return await productRepository.GetProductByProductNumberAsync(productNumber);
        }


        public async Task<Product> DeleteProductAsync(int productNumber)
        {
            var existingProduct = await productRepository.GetProductByProductNumberAsync(productNumber);

            productRepository.DeleteProduct(existingProduct);
            await unitOfWork.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            productRepository.CreateProduct(product);
            await unitOfWork.SaveChangesAsync();
            return product;

        }

        public async Task<Product> UpdateProductAsync(int productNumber, Product product)
        {
            var existingProduct = await productRepository.GetProductByProductNumberAsync(productNumber);
            productRepository.UpdateProduct(product);
            await unitOfWork.SaveChangesAsync();
            return existingProduct;
        }
    }
}
