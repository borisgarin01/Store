using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CategoriesRepository : ICategoriesRepository
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
