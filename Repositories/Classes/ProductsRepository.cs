using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ProductsRepository:IProductsRepository
    {
        public ProductsRepository()
        {
        }

        public Task Create(Product item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Product item)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
