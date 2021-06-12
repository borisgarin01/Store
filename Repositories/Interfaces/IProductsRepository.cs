using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task Create(Product product);
        public Task<Product> Get(long id);
        public Task Update(Product product);
        public Task Delete(Product product);
    }
}
