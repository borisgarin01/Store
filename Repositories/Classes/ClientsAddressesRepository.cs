using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsAddressesRepository : IClientsAddressesRepository
    {
        private StoreContext storeContext;

        public ClientsAddressesRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ClientAddress clientAddress)
        {
            storeContext.ClientsAddresses.Add(clientAddress);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ClientAddress clientAddress)
        {
            storeContext.ClientsAddresses.Remove(clientAddress);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ClientAddress> Get(long id)
        {
            return await storeContext.ClientsAddresses.FirstOrDefaultAsync(clientAddress => clientAddress.Id == id);
        }

        public async Task<IEnumerable<ClientAddress>> GetAll()
        {
            return await storeContext.ClientsAddresses.ToListAsync();
        }

        public async Task Update(ClientAddress clientAddress)
        {
            storeContext.ClientsAddresses.Update(clientAddress);
            await storeContext.SaveChangesAsync();
        }
    }
}
