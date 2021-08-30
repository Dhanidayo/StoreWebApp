using System;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using StoreManagement.Models;
using StoreManagement.DB;
using Microsoft.AspNetCore.Identity;

namespace StoreManagement.BL
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
        }

        public async Task<Store> AddStore(string storeName, int products, string userId, string location, int branches)
        {
            Store store = new Store
            {
                StoreName = storeName,
                UserId = userId,
                Location = location,
                Branches = branches,
                Products = products
            };
            var result = await _storeRepository.AddStore(store);
            if (result != null)
            {
                return result;
            }
            throw new TimeoutException("Unable to create store instance at this time");
        }

        public async Task<Store> GetStore(string storeId)
        {
            return await _storeRepository.GetStore(storeId);
        }

        public async Task<bool> UpdateStore_Put(StorePutRequest storeDTO, string StoreId, string userId)
        {
            try
            {
                var store = await GetStore(StoreId);

                if (store is null)
                {
                    return false;
                }

                if (store.UserId != userId)
                {
                    throw new UnauthorizedAccessException("Forbidden");
                }

                store.StoreName = storeDTO.StoreName;
                store.Location = storeDTO.Location;
                store.Branches = storeDTO.Branches;

                return await _storeRepository.UpdateStore(store);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<bool> UpdateStore_Patch(StorePatchRequest storeDTO, string storeId, string userId)
        {
            try
            {
                var store = await GetStore(storeId);

                if (store.UserId != userId)
                {
                    throw new UnauthorizedAccessException("Forbidden");
                }

                store.StoreName = storeDTO.StoreName ?? store.StoreName;
                store.Location = storeDTO.Location ?? store.Location;
                store.Branches = storeDTO.Branches != 0 ? storeDTO.Branches: store.Branches;

                return await _storeRepository.UpdateStore(store);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }       

        public async Task<bool> DeleteStore(string storeId, string userId)
        {
            var store = await GetStore(storeId);
            if (store.UserId == userId)
            {
                return await _storeRepository.DeleteStore(storeId);
            }

            throw new UnauthorizedAccessException("Forbidden");
        }

        public async Task<ICollection<Store>> GetAllUserStores(string userId)
        {
            return await _storeRepository.GetAllUserStores(userId);
        }
    }
}