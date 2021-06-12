using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class LeftoversInStoresRepository : ILeftoversInStoresRepository
    {
        private StoreContext storeContext;

        public LeftoversInStoresRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(LeftoversInStore leftoversInStore)
        {
            storeContext.LeftoversInStores.Add(leftoversInStore);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(LeftoversInStore leftoversInStore)
        {
            storeContext.LeftoversInStores.Remove(leftoversInStore);
            await storeContext.SaveChangesAsync();
        }

        public async Task<LeftoversInStore> Get(long id)
        {
            return await storeContext.LeftoversInStores.FindAsync(id);
        }

        public async Task<IEnumerable<LeftoversInStore>> GetAll()
        {
            return await storeContext.LeftoversInStores.ToListAsync();
        }

        public async Task Update(LeftoversInStore leftoversInStore)
        {
            storeContext.LeftoversInStores.Update(leftoversInStore);
            await storeContext.SaveChangesAsync();
        }
    }
}
