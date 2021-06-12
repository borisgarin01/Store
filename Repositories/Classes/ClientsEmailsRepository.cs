using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsEmailsRepository:IClientsEmailsRepository
    {
        private StoreContext storeContext;

        public ClientsEmailsRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ClientEmail clientEmail)
        {
            storeContext.ClientsEmails.Add(clientEmail);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ClientEmail clientEmail)
        {
            storeContext.ClientsEmails.Remove(clientEmail);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ClientEmail> Get(long id)
        {
            return await storeContext.ClientsEmails.FirstOrDefaultAsync(clientEmail => clientEmail.Id == id);
        }

        public async Task<IEnumerable<ClientEmail>> GetAll()
        {
            return await storeContext.ClientsEmails.ToListAsync();
        }

        public async Task Update(ClientEmail clientEmail)
        {
            storeContext.ClientsEmails.Update(clientEmail);
            await storeContext.SaveChangesAsync();
        }
    }
}
