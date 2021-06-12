using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class StoresRepository : IStoresRepository
    {
        private StoreContext storeContext;

        public StoresRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Models.Store store)
        {
            storeContext.Stores.Add(store);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Models.Store store)
        {
            storeContext.Stores.Remove(store);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Models.Store> Get(long id)
        {
            return await storeContext.Stores.FirstOrDefaultAsync(store => store.Id == id);
        }

        public async Task<IEnumerable<Models.Store>> GetAll()
        {
            return await storeContext.Stores.ToListAsync();
        }

        public async Task Update(Models.Store store)
        {
            storeContext.Stores.Update(store);
            await storeContext.SaveChangesAsync();
        }
    }
}
