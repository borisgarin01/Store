using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsPhonesNumbersRepository:IClientsPhonesNumbersRepository
    {
        public ClientsPhonesNumbersRepository()
        {
        }

        public Task Create(ClientsPhonesNumber item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ClientsPhonesNumber item)
        {
            throw new NotImplementedException();
        }

        public Task<ClientsPhonesNumber> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientsPhonesNumber>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientsPhonesNumber item)
        {
            throw new NotImplementedException();
        }
    }
}
