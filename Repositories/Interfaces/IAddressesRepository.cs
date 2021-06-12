using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IAddressesRepository
    {
        public Task<IEnumerable<Address>> GetAll();
        public Task Create(Address address);
        public Task<Address> Get(long id);
        public Task Update(Address address);
        public Task Delete(Address address);
    }
}
