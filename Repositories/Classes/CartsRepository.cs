using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CartsRepository:ICartsRepository
    {
        public CartsRepository()
        {
        }

        public Task Create(Cart item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Cart item)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Cart item)
        {
            throw new NotImplementedException();
        }
    }
}
