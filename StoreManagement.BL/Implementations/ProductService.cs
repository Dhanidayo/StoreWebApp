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

        public async Task<Product> AddProduct(string productName, double price, string storeId)
        {
            return await _productRepository.AddProduct(new Product { ProductName = productName, Price = price, StoreId = storeId });
        }

        public Task<Product> GetProduct(string productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public async Task<bool> UpdateProduct_patch(string productId, string storeId, UpdateProductRequest productDTO)
        {
            try
            {
                var product = await GetProduct(productId);
                if (product is null)
                {
                    throw new ArgumentNullException("Resource does not exist");
                }

                if (product.StoreId != storeId)
                {
                    throw new UnauthorizedAccessException("Forbidden");
                }

                product.ProductName = productDTO.ProductName;
                product.Price = productDTO.Price;

                return await _productRepository.UpdateProduct(product);
            }
            catch (Exception)
            {
                
                throw new Exception();
            }
        }

        public async Task<bool> UpdateProduct_put(string productId, string storeId, UpdateProductRequest productDTO)
        {
            try
            {
                var product = await GetProduct(productId);
                if (product is null)
                {
                    throw new ArgumentNullException("Resource does not exist");
                }

                if (product.StoreId != storeId)
                {
                    throw new UnauthorizedAccessException("Forbidden");
                }

                product.ProductName = productDTO.ProductName;
                product.Price = productDTO.Price;

                return await _productRepository.UpdateProduct(product);
            }
            catch (Exception)
            {
                
                throw new Exception();
            }
        }

        public Task<bool> DeleteProduct(string productId)
        {
            //var product = await GetProduct(productId);
            //if (product.StoreId == storeId)
            //{
                return _productRepository.DeleteProduct(productId);
            //}

            //throw new UnauthorizedAccessException("Forbidden");
        }

        public Task<ICollection<Product>> GetAllProducts(string storeId)
        {
            return _productRepository.GetAllProducts(storeId);
        }
    }
}