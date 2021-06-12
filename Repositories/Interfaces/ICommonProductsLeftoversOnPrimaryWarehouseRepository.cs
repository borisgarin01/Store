using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface ICommonProductsLeftoversOnPrimaryWarehouseRepository
    {
        public Task<IEnumerable<CommonProductLeftoversOnPrimaryWarehouse>> GetAll();
        public Task Create(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse);
        public Task<CommonProductLeftoversOnPrimaryWarehouse> Get(long id);
        public Task Update(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse);
        public Task Delete(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse);
    }
}
