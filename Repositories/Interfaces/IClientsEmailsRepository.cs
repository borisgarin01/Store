using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IClientsEmailsRepository
    {
        public Task<IEnumerable<ClientEmail>> GetAll();
        public Task Create(ClientEmail clientEmail);
        public Task<ClientEmail> Get(long id);
        public Task Update(ClientEmail clientEmail);
        public Task Delete(ClientEmail clientEmail);
    }
}
