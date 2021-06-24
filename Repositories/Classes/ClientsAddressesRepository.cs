using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsAddressesRepository:IClientsAddressesRepository
    {
        public ClientsAddressesRepository()
        {
        }

        public Task Create(ClientsAddress item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ClientsAddress item)
        {
            throw new NotImplementedException();
        }

        public Task<ClientsAddress> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientsAddress>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientsAddress item)
        {
            throw new NotImplementedException();
        }
    }
}
