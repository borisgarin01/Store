using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ClientsEmailsRepository:IClientsEmailsRepository
    {
        public ClientsEmailsRepository()
        {
        }

        public Task Create(ClientsEmail item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ClientsEmail item)
        {
            throw new NotImplementedException();
        }

        public Task<ClientsEmail> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientsEmail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientsEmail item)
        {
            throw new NotImplementedException();
        }
    }
}
