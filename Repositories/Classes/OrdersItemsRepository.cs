using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class OrdersItemsRepository:IOrdersItemsRepository
    {
        private StoreContext storeContext;

        public OrdersItemsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(OrdersItem orderItem)
        {
            storeContext.OrdersItems.Add(orderItem);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(OrdersItem orderItem)
        {
            storeContext.OrdersItems.Remove(orderItem);
            await storeContext.SaveChangesAsync();
        }

        public async Task<OrdersItem> Get(long id)
        {
            return await storeContext.OrdersItems.FirstOrDefaultAsync(orderItem => orderItem.Id == id);
        }

        public async Task<IEnumerable<OrdersItem>> GetAll()
        {
            return await storeContext.OrdersItems.ToListAsync();
        }

        public async Task Update(OrdersItem orderItem)
        {
            storeContext.OrdersItems.Update(orderItem);
            await storeContext.SaveChangesAsync();
        }
    }
}
