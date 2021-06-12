using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IClientsAddressesRepository
    {
        public Task<IEnumerable<ClientAddress>> GetAll();
        public Task Create(ClientAddress clientAddress);
        public Task<ClientAddress> Get(long id);
        public Task Update(ClientAddress clientAddress);
        public Task Delete(ClientAddress clientAddress);
    }
}
