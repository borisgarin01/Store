using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IClientsRepository
    {
        public Task<IEnumerable<Client>> GetAll();
        public Task Create(Client client);
        public Task<Client> Get(long id);
        public Task Update(Client client);
        public Task Delete(Client client);
    }
}
