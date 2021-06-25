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
    public class ProductsKindsRepository:IProductsKindsRepository
    {
        private StoreContext storeContext;

        public ProductsKindsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ProductsKind productKind)
        {
            storeContext.ProductsKinds.Add(productKind);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ProductsKind productsKind)
        {
            List<Product> productsToDelete = storeContext.Products.Where(p => p.ProductKindId == productsKind.Id).ToList();
            foreach (Product product in productsToDelete)
            {
                storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.ProductId == product.Id));
                storeContext.CommonProductsLeftoversOnPrimaryWarehouses.RemoveRange(storeContext.CommonProductsLeftoversOnPrimaryWarehouses.Where(ci => ci.ProductId == product.Id));
                storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(ci => ci.ProductId == product.Id));
                storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(ci => ci.ProductId == product.Id));
            }
            storeContext.Products.RemoveRange(productsToDelete);
            storeContext.ProductsKinds.Remove(productsKind);
            await storeContext.SaveChangesAsync();
            await storeContext.SaveChangesAsync();
        }

        public async Task<ProductsKind> Get(long id)
        {
            return await storeContext.ProductsKinds.FirstOrDefaultAsync(productKind => productKind.Id == id);
        }

        public async Task<IEnumerable<ProductsKind>> GetAll()
        {
            return await storeContext.ProductsKinds.ToListAsync();
        }

        public async Task Update(ProductsKind productKind)
        {
            storeContext.ProductsKinds.Update(productKind);
            await storeContext.SaveChangesAsync();
        }
    }
}
