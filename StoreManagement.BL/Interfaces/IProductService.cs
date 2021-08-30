using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;

namespace StoreManagement.BL
{
    public interface IProductService
    {
        Task<Product> AddProduct(string productName, string storeId);
        Task<bool> UpdateProduct(string productId, string productName);
        Task<bool> DeleteProduct(string productId);
        Task<Product> GetProduct(string productId);
        Task<ICollection<Product>> GetAllProducts(string storeId);
    }
}