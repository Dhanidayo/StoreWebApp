using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Models;

namespace StoreManagement.DB
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDBContext context;

        public StoreRepository(StoreDBContext context)
        {
            this.context = context;
        }

        public async Task<Store> AddStore(Store store)
        {
            await context.AddAsync(store);
            var result = await context.SaveChangesAsync();

            if (result > 0)
            {
                return store;
            }
            return store;
        }

        public async Task<Store> GetStore(string storeId)
        {
            Store store = await context.Stores
                .Include(store => store.User)
                .FirstOrDefaultAsync(store => store.StoreId == storeId);
            if (store is null)
            {
                throw new ArgumentNullException("Resource does not exist");
            }
            return store;
        }

        public async Task<bool> DeleteStore(string storeId)
        {
            Store store = await context.Stores.FirstOrDefaultAsync(store => store.StoreId == storeId);
            if (store == null)
            {
                return false;
            }
            context.Remove(store);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateStore(Store store)
        {
            if (await context.Stores.FirstOrDefaultAsync(store => store.StoreId == store.StoreId) is null)
            {
                return false;
            }
            context.Stores.Update(store);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ICollection<Store>> GetAllUserStores(string userId)
        {
            return await context.Stores.Where(store => store.UserId == userId).ToListAsync();
        }
    }
}
