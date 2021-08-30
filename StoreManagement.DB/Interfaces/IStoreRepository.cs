using System;
using System.Threading.Tasks;
using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.DB
{
    public interface IStoreRepository
    {
        Task<Store> AddStore(Store store);
        Task<Store> GetStore(string storeId);
        Task<bool> DeleteStore(string storeId);
        Task<bool> UpdateStore(Store store);
        Task<ICollection<Store>> GetAllUserStores(string userId);
    }
}