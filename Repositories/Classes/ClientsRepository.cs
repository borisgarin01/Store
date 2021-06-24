using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsRepository:IClientsRepository
    {
        public ClientsRepository()
        {
        }

        public Task Create(Client item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Client item)
        {
            throw new NotImplementedException();
        }

        public Task<Client> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
