using System;
using System.Text;
using System.Collections.Generic;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class StoreMapping
    {
        public static AddStoreResponse GetAddStoreResponse(Store store)
        {
            return new AddStoreResponse
            {
                StoreName = store.StoreName,
                StoreType = store.StoreType,
                Branches = store.Branches,
                StoreId = store.StoreId,
                Products = store.Products,
                Location = store.Location,
                UserId = store.UserId
            };
        }

        public static GetStoreResponse GetStoreResponse(Store store)
        {
            return new GetStoreResponse
            {
                StoreId = store.StoreId,
                StoreName = store.StoreName,
                StoreType = store.StoreType,
                Branches = store.Branches,
                Products = store.Products,
                Location = store.Location,
                Product = store.Product,
                User = store.User,
                UserId = store.UserId
            };
        }
    }
}