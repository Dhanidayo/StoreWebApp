using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;
using StoreManagement.DB;

namespace StoreManagement.BL
{
    public interface IProductService
    {
        Task<Product> AddProduct(string productName, double price, string storeId);
        Task<bool> UpdateProduct_patch(string productId, string storeId, UpdateProductRequest productDTO);
        Task<bool> UpdateProduct_put(string productId, string storeId, UpdateProductRequest productDTO);
        Task<bool> DeleteProduct(string productId);
        Task<Product> GetProduct(string productId);
        Task<ICollection<Product>> GetAllProducts(string storeId);
    }
}