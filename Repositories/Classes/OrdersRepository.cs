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
    public class OrdersRepository:IOrdersRepository
    {
        private StoreContext storeContext;

        public OrdersRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Order order)
        {
            storeContext.Orders.Add(order);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(oi => oi.OrderId == order.Id));
            storeContext.Orders.Remove(order);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Order> Get(long id)
        {
            return await storeContext.Orders.FirstOrDefaultAsync(order => order.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await storeContext.Orders.ToListAsync();
        }

        public async Task Update(Order order)
        {
            storeContext.Orders.Update(order);
            await storeContext.SaveChangesAsync();
        }
    }
}
