using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface ICartsRepository
    {
        public Task<IEnumerable<Cart>> GetAll();
        public Task Create(Cart cart);
        public Task<Cart> Get(long id);
        public Task Update(Cart cart);
        public Task Delete(Cart cart);
    }
}
