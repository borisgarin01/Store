using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface ILeftoversInStoresRepository
    {
        public Task<IEnumerable<LeftoversInStore>> GetAll();
        public Task Create(LeftoversInStore leftoversInStore);
        public Task<LeftoversInStore> Get(long id);
        public Task Update(LeftoversInStore leftoversInStore);
        public Task Delete(LeftoversInStore leftoversInStore);
    }
}
