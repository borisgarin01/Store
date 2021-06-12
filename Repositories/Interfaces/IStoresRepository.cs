using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Repositories.Interfaces
{
    public interface IStoresRepository
    {
        public Task<IEnumerable<Models.Store>> GetAll();
        public Task Create(Models.Store store);
        public Task<Models.Store> Get(long id);
        public Task Update(Models.Store store);
        public Task Delete(Models.Store store);
    }
}
