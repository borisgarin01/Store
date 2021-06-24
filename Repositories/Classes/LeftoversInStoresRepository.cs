using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class LeftoversInStoresRepository:ILeftoversInStoresRepository
    {
        public LeftoversInStoresRepository()
        {
        }

        public Task Create(LeftoversInStore item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(LeftoversInStore item)
        {
            throw new NotImplementedException();
        }

        public Task<LeftoversInStore> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LeftoversInStore>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(LeftoversInStore item)
        {
            throw new NotImplementedException();
        }
    }
}
