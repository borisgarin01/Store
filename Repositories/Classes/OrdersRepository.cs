using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class OrdersRepository:IOrdersRepository
    {
        public OrdersRepository()
        {
        }

        public Task Create(Order item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
