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

        public async Task Create(ClientsEmail clientsEmail)
        {
            storeContext.ClientsEmails.Add(clientsEmail);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ClientsEmail clientsEmail)
        {
            storeContext.ClientsEmails.Remove(clientsEmail);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ClientsEmail> Get(long id)
        {
            return await storeContext.ClientsEmails.FirstOrDefaultAsync(clientEmail => clientEmail.Id == id);
        }

        public async Task<IEnumerable<ClientsEmail>> GetAll()
        {
            return await storeContext.ClientsEmails.ToListAsync();
        }

        public async Task Update(ClientsEmail clientsEmail)
        {
            storeContext.ClientsEmails.Update(clientsEmail);
            await storeContext.SaveChangesAsync();
        }
    }
}
