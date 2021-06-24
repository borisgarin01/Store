using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Repositories.Interfaces.Base
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(long id);
        public Task Create(T item);
        public Task Update(T item);
        public Task Delete(T item);
    }
}
