using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string productId);
        Task<Product> GetProduct(string productId);
        Task<ICollection<Product>> GetAllProducts(string storeId);
    }
}