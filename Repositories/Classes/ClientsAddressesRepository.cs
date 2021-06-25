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
    public class ClientsAddressesRepository:IClientsAddressesRepository
    {
        private StoreContext storeContext;

        public ClientsAddressesRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ClientsAddress clientsAddress)
        {
            storeContext.ClientsAddresses.Add(clientsAddress);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ClientsAddress clientsAddress)
        {
            List<Order> orders = storeContext.Orders.Where(o => o.ClientAddressId == clientsAddress.Id).ToList();
            foreach(Order order in storeContext.Orders.Where(oi => oi.ClientAddressId == clientsAddress.Id))
            {
                storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(oi => oi.OrderId == order.Id));
            }
            storeContext.Orders.RemoveRange(storeContext.Orders.Where(o => o.ClientAddressId == clientsAddress.Id));
            storeContext.ClientsAddresses.Remove(clientsAddress);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ClientsAddress> Get(long id)
        {
            return await storeContext.ClientsAddresses.FirstOrDefaultAsync(clientAddress => clientAddress.Id == id);
        }

        public async Task<IEnumerable<ClientsAddress>> GetAll()
        {
            return await storeContext.ClientsAddresses.ToListAsync();
        }

        public async Task Update(ClientsAddress clientsAddress)
        {
            storeContext.ClientsAddresses.Update(clientsAddress);
            await storeContext.SaveChangesAsync();
        }
    }
}
