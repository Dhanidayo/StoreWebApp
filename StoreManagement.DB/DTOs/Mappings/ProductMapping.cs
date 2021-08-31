using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class ProductMapping
    {
        public static AddProductResponse GetAddProductResponse(Product product)
        {
            return new AddProductResponse
            {
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                Price = product.Price,
                StoreId = product.StoreId
            };
        }

        public static GetProductResponse GetProductResponse(Product product)
        {
            return new GetProductResponse
            {
                StoreId = product.StoreId,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Store = product.Store
            };
        }
    }
}