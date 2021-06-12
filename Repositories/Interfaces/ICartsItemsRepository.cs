using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface ICartsItemsRepository
    {
        public Task<IEnumerable<CartItem>> GetAll();
        public Task Create(CartItem cartItem);
        public Task<CartItem> Get(long id);
        public Task Update(CartItem cartItem);
        public Task Delete(CartItem cartItem);
    }
}
