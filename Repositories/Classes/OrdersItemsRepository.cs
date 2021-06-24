using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class OrdersItemsRepository:IOrdersItemsRepository
    {
        public OrdersItemsRepository()
        {
        }

        public Task Create(OrdersItem item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(OrdersItem item)
        {
            throw new NotImplementedException();
        }

        public Task<OrdersItem> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrdersItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(OrdersItem item)
        {
            throw new NotImplementedException();
        }
    }
}
