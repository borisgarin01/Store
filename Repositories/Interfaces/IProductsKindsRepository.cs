using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IProductsKindsRepository
    {
        public Task<IEnumerable<ProductKind>> GetAll();
        public Task Create(ProductKind productKind);
        public Task<ProductKind> Get(long id);
        public Task Update(ProductKind productKind);
        public Task Delete(ProductKind productKind);
    }
}
