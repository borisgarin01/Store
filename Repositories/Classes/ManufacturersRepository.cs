using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ManufacturersRepository:IManufacturersRepository
    {
        private StoreContext storeContext;

        public ManufacturersRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Manufacturer manufacturer)
        {
            storeContext.Manufacturers.Add(manufacturer);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Manufacturer manufacturer)
        {
            storeContext.Manufacturers.Remove(manufacturer);

            foreach (var product in storeContext.Products.Where(p => p.ManufacturerId == manufacturer.Id))
            {
                storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.ProductId == product.Id));
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.RemoveRange(storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Where(cplopw => cplopw.ProductId == product.Id));
                storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(lis => lis.ProductId == product.Id));
                storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(oi => oi.ProductId == product.Id));

                storeContext.Products.Remove(product);
            }

            await storeContext.SaveChangesAsync();
        }

        public async Task<Manufacturer> Get(long id)
        {
            return await storeContext.Manufacturers.FirstOrDefaultAsync(manufacturer => manufacturer.Id == id);
        }

        public async Task<IEnumerable<Manufacturer>> GetAll()
        {
            return await storeContext.Manufacturers.ToListAsync();
        }

        public async Task Update(Manufacturer manufacturer)
        {
            storeContext.Manufacturers.Update(manufacturer);
            await storeContext.SaveChangesAsync();
        }
    }
}
