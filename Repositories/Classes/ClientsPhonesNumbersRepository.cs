using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsPhonesNumbersRepository:IClientsPhonesNumbersRepository
    {
        private StoreContext storeContext;

        public ClientsPhonesNumbersRepository(StoreContext context)
        {
            storeContext = context;
        }

        public async Task Create(ClientsPhonesNumber clientsPhonesNumber)
        {
            storeContext.ClientsPhonesNumbers.Add(clientsPhonesNumber);
            await storeContext.SaveChangesAsync();
        }

        public async Task Delete(ClientsPhonesNumber clientsPhonesNumber)
        {
            storeContext.ClientsPhonesNumbers.Remove(clientsPhonesNumber);
            await storeContext.SaveChangesAsync();
        }

        public async Task<ClientsPhonesNumber> Get(long id)
        {
            return await storeContext.ClientsPhonesNumbers.FirstOrDefaultAsync(clientPhoneNumber => clientPhoneNumber.Id == id);
        }

        public async Task<IEnumerable<ClientsPhonesNumber>> GetAll()
        {
            return await storeContext.ClientsPhonesNumbers.ToListAsync();
        }

        public async Task Update(ClientsPhonesNumber clientsPhonesNumber)
        {
            storeContext.ClientsPhonesNumbers.Update(clientsPhonesNumber);
            await storeContext.SaveChangesAsync();
        }
    }
}
