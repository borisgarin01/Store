using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ProductsKindsRepository : IProductsKindsRepository
    {
        private StoreContext storeContext;

        public ProductsKindsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ProductKind productKind)
        {
            storeContext.ProductsKinds.Add(productKind);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ProductKind productKind)
        {
            storeContext.ProductsKinds.Remove(productKind);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ProductKind> Get(long id)
        {
            return await storeContext.ProductsKinds.FirstOrDefaultAsync(productKind => productKind.Id == id);
        }

        public async Task<IEnumerable<ProductKind>> GetAll()
        {
            return await storeContext.ProductsKinds.ToListAsync();
        }

        public async Task Update(ProductKind productKind)
        {
            storeContext.ProductsKinds.Update(productKind);
            await storeContext.SaveChangesAsync();
        }
    }
}
