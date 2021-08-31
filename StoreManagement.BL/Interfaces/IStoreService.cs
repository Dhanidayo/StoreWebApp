using System;
using System.Threading.Tasks;
using StoreManagement.DB;
using StoreManagement.Models;
using System.Collections.Generic;

namespace StoreManagement.BL
{
    public interface IStoreService
    {
        Task<Store> AddStore(string storeName, string storeType, int products, string userId, string location, int branches);
        Task<Store> GetStore(string storeId);
        Task<bool> UpdateStore_Put(StorePutRequest storeDTO, string storeId,string userId);
        Task<bool> UpdateStore_Patch(StorePatchRequest storeDTO, string storeId, string userId);
        Task<bool> DeleteStore(string storeId, string userId);
        Task<ICollection<Store>> GetAllUserStores(string userId);
    }
}