﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManicOceanic.DOMAIN.Entities.Products;

namespace ManicOceanic.DOMAIN.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListProductsAsync();
        Task<Product> GetProductByProductNumberAsync(int productNumber);
        Task<Product> DeleteProductAsync(int productNumber);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<Product> GetProductByCategoryIdAsync(int categoryId);
        Task<Product> GetRandomProductAsync();
        Task<IEnumerable<Product>> GetProductBySearchAsync(string searchWord);
        Task<Product> GetProductByIdAsync(Guid id);

    }
}
