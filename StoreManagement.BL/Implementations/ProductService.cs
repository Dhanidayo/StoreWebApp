using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using StoreManagement.BL;
using StoreManagement.Models;
using StoreManagement.DB;

namespace StoreManagement.BL
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> AddProduct(string productName, string storeId)
        {
            return await _productRepository.AddProduct(new Product { ProductName = productName, StoreId = storeId });
        }

        public async Task<bool> UpdateProduct(string productId, string productName)
        {
            var product = await _productRepository.GetProduct(productId);
            if (product is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }

            product.ProductName = productName;

            return await _productRepository.UpdateProduct(product);
        }

        public Task<bool> DeleteProduct(string productId)
        {
            return _productRepository.DeleteProduct(productId);
        }

        public Task<Product> GetProduct(string productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public Task<ICollection<Product>> GetAllProducts(string storeId)
        {
            return _productRepository.GetAllProducts(storeId);
        }
    }
}