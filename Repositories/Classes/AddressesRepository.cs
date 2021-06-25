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
    public class AddressesRepository:IAddressesRepository
    {
        private StoreContext storeContext;
        
        public AddressesRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Address address)
        {
            storeContext.Addresses.Add(address);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Address address)
        {
            List<Order> ordersToDelete = new List<Order>();
            List<OrdersItem> ordersItemsToDelete = new List<OrdersItem>();
            List<ClientsAddress> clientsAddressesToDelete = storeContext.ClientsAddresses.Where(s => s.AddressId == address.Id).ToList();
            foreach(var clientAddress in clientsAddressesToDelete)
            {
                ordersToDelete.AddRange(storeContext.Orders.Where(o => o.ClientAddressId == clientAddress.Id));
                foreach(var order in ordersToDelete)
                {
                    ordersItemsToDelete.AddRange(storeContext.OrdersItems.Where(oi => oi.OrderId == order.Id));
                }
            }

            List<Models.Store> storesToDelete = storeContext.Stores.Where(s => s.AddressId == address.Id).ToList();

            foreach(Models.Store store in storesToDelete)
            {
                storeContext.LeftoversInStores.RemoveRange(storeContext.LeftoversInStores.Where(lis => lis.StoreId == store.Id));
            }

            storeContext.OrdersItems.RemoveRange(ordersItemsToDelete);
            storeContext.Orders.RemoveRange(ordersToDelete);
            storeContext.ClientsAddresses.RemoveRange(clientsAddressesToDelete);
            storeContext.Stores.RemoveRange(storeContext.Stores.Where(s => s.AddressId == address.Id));
            storeContext.Addresses.Remove(address);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Address> Get(long id)
        {
            return await storeContext.Addresses.FirstOrDefaultAsync(address => address.Id == id);
        }

        public async Task<IEnumerable<Address>> GetAll()
        {
            return await storeContext.Addresses.ToListAsync();
        }

        public async Task Update(Address address)
        {
            storeContext.Addresses.Update(address);
            await storeContext.SaveChangesAsync();
        }
    }
}
