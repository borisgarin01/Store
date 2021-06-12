using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsRepository : IClientsRepository
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
