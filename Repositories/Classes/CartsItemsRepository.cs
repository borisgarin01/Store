using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CartsItemsRepository:ICartsItemsRepository
    {
        private StoreContext storeContext;

        public CartsItemsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(CartsItem cartsItem)
        {
            storeContext.CartsItems.Add(cartsItem);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(CartsItem cartsItem)
        {
            storeContext.CartsItems.Remove(cartsItem);
            await storeContext.SaveChangesAsync();
        }

        public async Task<CartsItem> Get(long id)
        {
            return await storeContext.CartsItems.FirstOrDefaultAsync(cartItem => cartItem.Id == id);
        }

        public async Task<IEnumerable<CartsItem>> GetAll()
        {
            return await storeContext.CartsItems.ToListAsync();
        }

        public async Task Update(CartsItem cartsItem)
        {
            storeContext.CartsItems.Update(cartsItem);
            await storeContext.SaveChangesAsync();
        }
    }
}
