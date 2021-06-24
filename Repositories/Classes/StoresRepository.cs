using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class StoresRepository:IStoresRepository
    {
        public StoresRepository()
        {
        }

        public Task Create(Models.Store item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Models.Store item)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Store> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Store>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Models.Store item)
        {
            throw new NotImplementedException();
        }
    }
}
