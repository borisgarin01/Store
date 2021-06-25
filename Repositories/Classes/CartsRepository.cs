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
    public class CartsRepository:ICartsRepository
    {
        private StoreContext storeContext;

        public CartsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Cart cart)
        {
            storeContext.Carts.Add(cart);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Cart cart)
        {
            storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.CartId == cart.Id));
            storeContext.Carts.Remove(cart);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Cart> Get(long id)
        {
            return await storeContext.Carts.FirstOrDefaultAsync(cart => cart.Id == id);
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            return await storeContext.Carts.ToListAsync();
        }

        public async Task Update(Cart cart)
        {
            storeContext.Carts.Update(cart);
            await storeContext.SaveChangesAsync();
        }
    }
}
