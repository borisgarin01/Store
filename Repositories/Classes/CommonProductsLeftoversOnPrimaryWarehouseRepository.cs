using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CommonProductsLeftoversOnPrimaryWarehouseRepository : ICommonProductsLeftoversOnPrimaryWarehouseRepository
    {
        private StoreContext storeContext;

        public CommonProductsLeftoversOnPrimaryWarehouseRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            storeContext.CommonProductLeftoversOnPrimaryWarehouses.Add(commonProductLeftoversOnPrimaryWarehouse);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            storeContext.CommonProductLeftoversOnPrimaryWarehouses.Remove(commonProductLeftoversOnPrimaryWarehouse);
            await storeContext.SaveChangesAsync();
        }

        public async Task<CommonProductLeftoversOnPrimaryWarehouse> Get(long id)
        {
            return await storeContext.CommonProductLeftoversOnPrimaryWarehouses.FirstOrDefaultAsync(commonProductLeftoverOnPrimaryWarehouse => commonProductLeftoverOnPrimaryWarehouse.Id == id);
        }

        public async Task<IEnumerable<CommonProductLeftoversOnPrimaryWarehouse>> GetAll()
        {
            return await storeContext.CommonProductLeftoversOnPrimaryWarehouses.ToListAsync();
        }

        public async Task Update(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            storeContext.CommonProductLeftoversOnPrimaryWarehouses.Update(commonProductLeftoversOnPrimaryWarehouse);
            await storeContext.SaveChangesAsync();
        }
    }
}
