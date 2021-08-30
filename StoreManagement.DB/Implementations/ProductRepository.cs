using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDBContext _storeDBContext;

        public ProductRepository(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext ?? throw new ArgumentNullException(nameof(storeDBContext));
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _storeDBContext.AddAsync(product);
            var result = await _storeDBContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (await _storeDBContext.Products.FirstOrDefaultAsync(product => product.ProductId == product.ProductId) is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }

            _storeDBContext.Products.Update(product);
            var result = await _storeDBContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteProduct(string productId)
        {
            Product product = await _storeDBContext.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
            if (product == null)
            {
                return false;
            }

            _storeDBContext.Remove(product);

            var result = await _storeDBContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<Product> GetProduct(string productId)
        {
            Product product = await _storeDBContext.Products.FirstOrDefaultAsync(product => product.ProductId == productId);
            if (product is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return product;
        }

        public async Task<ICollection<Product>> GetAllProducts(string storeId)
        {
            return await _storeDBContext.Products.Where(product => product.StoreId == storeId).ToListAsync();
        }
    }
}