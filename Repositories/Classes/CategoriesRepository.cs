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
    public class CategoriesRepository:ICategoriesRepository
    {
        private StoreContext storeContext;

        public CategoriesRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Category category)
        {
            storeContext.Categories.Add(category);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            foreach(Product product in storeContext.Products.Where(p => p.CategoryId == category.Id))
            {
                storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.ProductId == product.Id));
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.RemoveRange(storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Where(cplopw => cplopw.ProductId == product.Id));
                storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(lis => lis.ProductId == product.Id));
                storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(oi => oi.ProductId == product.Id));
            }

            storeContext.Products.RemoveRange(storeContext.Products.Where(p => p.CategoryId == category.Id));
            storeContext.Categories.Remove(category);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Category> Get(long id)
        {
            return await storeContext.Categories.FirstOrDefaultAsync(category => category.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await storeContext.Categories.ToListAsync();
        }

        public async Task Update(Category category)
        {
            storeContext.Categories.Update(category);
            await storeContext.SaveChangesAsync();
        }
    }
}
