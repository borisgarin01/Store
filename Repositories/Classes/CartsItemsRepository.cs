using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CartsItemsRepository : ICartsItemsRepository
    {
        private StoreContext storeContext;

        public CartsItemsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(CartItem cartItem)
        {
            storeContext.CartsItems.Add(cartItem);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(CartItem cartItem)
        {
            storeContext.CartsItems.Remove(cartItem);
            await storeContext.SaveChangesAsync();
        }

        public async Task<CartItem> Get(long id)
        {
            return await storeContext.CartsItems.FirstOrDefaultAsync(cartItem=>cartItem.Id==id);
        }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
            return await storeContext.CartsItems.ToListAsync();
        }

        public async Task Update(CartItem cartItem)
        {
            storeContext.CartsItems.Update(cartItem);
            await storeContext.SaveChangesAsync();
        }
    }
}
