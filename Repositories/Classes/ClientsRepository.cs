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
    public class ClientsRepository:IClientsRepository
    {
        private StoreContext storeContext;

        public ClientsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(Client client)
        {
            storeContext.Clients.Add(client);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            List<Cart> cartsToDelete = storeContext.Carts.Where(c => c.ClientId == client.Id).ToList();
            foreach(Cart cart in cartsToDelete)
            {
                storeContext.CartsItems.RemoveRange(storeContext.CartsItems.Where(ci => ci.CartId == cart.Id));
            }
            storeContext.Carts.RemoveRange(cartsToDelete);

            List<ClientsAddress> clientsAddressesToDelete = storeContext.ClientsAddresses.Where(c => c.ClientId == client.Id).ToList();
            foreach(ClientsAddress clientsAddress in clientsAddressesToDelete)
            {
                List<Order> orders = storeContext.Orders.Where(o => o.ClientAddressId == clientsAddress.Id).ToList();
                foreach (Order order in storeContext.Orders.Where(oi => oi.ClientAddressId == clientsAddress.Id))
                {
                    storeContext.OrdersItems.RemoveRange(storeContext.OrdersItems.Where(oi => oi.OrderId == order.Id));
                }
                storeContext.Orders.RemoveRange(storeContext.Orders.Where(o => o.ClientAddressId == clientsAddress.Id));
                storeContext.ClientsAddresses.Remove(clientsAddress);
            }

            storeContext.ClientsEmails.RemoveRange(storeContext.ClientsEmails.Where(ce => ce.ClientId == client.Id));
            storeContext.ClientsPhonesNumbers.RemoveRange(storeContext.ClientsPhonesNumbers.Where(cpn => cpn.ClientId == client.Id));

            storeContext.Clients.Remove(client);
            await storeContext.SaveChangesAsync();
        }

        public async Task<Client> Get(long id)
        {
            return await storeContext.Clients.FirstOrDefaultAsync(client => client.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await storeContext.Clients.ToListAsync();
        }

        public async Task Update(Client client)
        {
            storeContext.Clients.Update(client);
            await storeContext.SaveChangesAsync();
        }
    }
}
