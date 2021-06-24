using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CartsItemsRepository:ICartsItemsRepository
    {
        public CartsItemsRepository()
        {
        }

        public Task Create(CartsItem item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CartsItem item)
        {
            throw new NotImplementedException();
        }

        public Task<CartsItem> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartsItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(CartsItem item)
        {
            throw new NotImplementedException();
        }
    }
}
