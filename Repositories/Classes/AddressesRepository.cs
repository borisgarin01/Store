using System;
using System.Collections.Generic;
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
