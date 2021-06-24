using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ProductsKindsRepository:IProductsKindsRepository
    {
        public ProductsKindsRepository()
        {
        }

        public Task Create(ProductsKind item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ProductsKind item)
        {
            throw new NotImplementedException();
        }

        public Task<ProductsKind> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductsKind>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductsKind item)
        {
            throw new NotImplementedException();
        }
    }
}
