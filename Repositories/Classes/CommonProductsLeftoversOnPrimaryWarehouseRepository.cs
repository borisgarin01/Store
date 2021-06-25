using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CommonProductsLeftoversOnPrimaryWarehouseRepository:ICommonProductsLeftoversOnPrimaryWarehouseRepository
    {
        private StoreContext storeContext;

        public CommonProductsLeftoversOnPrimaryWarehouseRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Add(commonProductsLeftoversOnPrimaryWarehouse);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Remove(commonProductsLeftoversOnPrimaryWarehouse);
            await storeContext.SaveChangesAsync();
        }

        public async Task<CommonProductsLeftoversOnPrimaryWarehouse> Get(long id)
        {
            return await storeContext.CommonProductsLeftoversOnPrimaryWarehouses.FirstOrDefaultAsync(commonProductLeftoversOnPrimaryWarehouse => commonProductLeftoversOnPrimaryWarehouse.Id == id);
        }

        public async Task<IEnumerable<CommonProductsLeftoversOnPrimaryWarehouse>> GetAll()
        {
            return await storeContext.CommonProductsLeftoversOnPrimaryWarehouses.ToListAsync();
        }

        public async Task Update(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Update(commonProductsLeftoversOnPrimaryWarehouse);
            await storeContext.SaveChangesAsync();
        }
    }
}
