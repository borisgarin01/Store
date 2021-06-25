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
    public class ProductsRepository:IProductsRepository
    {
        private StoreContext storeContext;

        public ProductsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Product product)
        {
            storeContext.Products.Add(product);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.ProductId == product.Id));
            storeContext.CommonProductsLeftoversOnPrimaryWarehouses.RemoveRange(storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Where(cplopw => cplopw.ProductId == product.Id));
            storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(lis => lis.ProductId == product.Id));
            storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(oi => oi.ProductId == product.Id));

            storeContext.Products.Remove(product);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Product> Get(long id)
        {
            return await storeContext.Products.FirstOrDefaultAsync(product => product.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await storeContext.Products.ToListAsync();
        }

        public async Task Update(Product product)
        {
            storeContext.Products.Update(product);
            await storeContext.SaveChangesAsync();
        }
    }
}
