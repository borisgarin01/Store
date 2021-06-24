using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class AddressesRepository:IAddressesRepository
    {
        public AddressesRepository()
        {
        }

        public Task Create(Address item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Address item)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Address item)
        {
            throw new NotImplementedException();
        }
    }
}
