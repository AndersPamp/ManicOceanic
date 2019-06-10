using System;
using System.Collections.Generic;
using System.Linq;
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
            var productList = await productRepository.ListProductsAsync();
            var productNumber = 0;

            var nbrOfProducts = productList.Count();
            if (nbrOfProducts == 0)
            {
                productNumber = 101;
            }
            else
            {
                productNumber = productList.Max(p => p.ProductNumber) + 1;
            }

            product.ProductNumber = productNumber;
            productRepository.CreateProduct(product);
            await unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            productRepository.UpdateProduct(product);
            await unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductByCategoryIdAsync(int categoryId)
        {
            return await productRepository.GetProductByCategoryIdAsync(categoryId);
        }

        public async Task<Product> GetRandomProductAsync()
        {
            return await productRepository.GetRandomProductAsync();
        }

        public async Task<IEnumerable<Product>> GetProductBySearchAsync(string searchWord)
        {
            return await productRepository.GetProductBySearchAsync(searchWord);
        }
        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await productRepository.GetProductByIdAsync(id);
        }
    }
}
