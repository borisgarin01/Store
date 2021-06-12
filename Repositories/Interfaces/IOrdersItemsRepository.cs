using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IOrdersItemsRepository
    {
        public Task<IEnumerable<OrderItem>> GetAll();
        public Task Create(OrderItem orderItem);
        public Task<OrderItem> Get(long id);
        public Task Update(OrderItem orderItem);
        public Task Delete(OrderItem orderItem);
    }
}
