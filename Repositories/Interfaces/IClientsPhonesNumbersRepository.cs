using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IClientsPhonesNumbersRepository
    {
        public Task<IEnumerable<ClientPhoneNumber>> GetAll();
        public Task Create(ClientPhoneNumber clientPhoneNumber);
        public Task<ClientPhoneNumber> Get(long id);
        public Task Update(ClientPhoneNumber clientPhoneNumber);
        public Task Delete(ClientPhoneNumber clientPhoneNumber);
    }
}
