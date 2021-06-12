using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsPhonesNumbersRepository : IClientsPhonesNumbersRepository
    {
        private StoreContext storeContext;

        public ClientsPhonesNumbersRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ClientPhoneNumber clientPhoneNumber)
        {
            storeContext.ClientsPhonesNumbers.Add(clientPhoneNumber);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ClientPhoneNumber clientPhoneNumber)
        {
            storeContext.ClientsPhonesNumbers.Remove(clientPhoneNumber);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ClientPhoneNumber> Get(long id)
        {
            return await storeContext.ClientsPhonesNumbers.FirstOrDefaultAsync(clientPhoneNumber => clientPhoneNumber.Id == id);
        }

        public async Task<IEnumerable<ClientPhoneNumber>> GetAll()
        {
            return await storeContext.ClientsPhonesNumbers.ToListAsync();
        }

        public async Task Update(ClientPhoneNumber clientPhoneNumber)
        {
            storeContext.ClientsPhonesNumbers.Update(clientPhoneNumber);
            await storeContext.SaveChangesAsync();
        }
    }
}
