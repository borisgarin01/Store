using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        public Task<IEnumerable<Order>> GetAll();
        public Task Create(Order order);
        public Task<Order> Get(long id);
        public Task Update(Order order);
        public Task Delete(Order order);
    }
}
