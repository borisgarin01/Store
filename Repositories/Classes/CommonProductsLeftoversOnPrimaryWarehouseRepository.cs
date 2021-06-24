using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CommonProductsLeftoversOnPrimaryWarehouseRepository:ICommonProductsLeftoversOnPrimaryWarehouseRepository
    {
        public CommonProductsLeftoversOnPrimaryWarehouseRepository()
        {
        }

        public Task Create(CommonProductsLeftoversOnPrimaryWarehouse item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CommonProductsLeftoversOnPrimaryWarehouse item)
        {
            throw new NotImplementedException();
        }

        public Task<CommonProductsLeftoversOnPrimaryWarehouse> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonProductsLeftoversOnPrimaryWarehouse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(CommonProductsLeftoversOnPrimaryWarehouse item)
        {
            throw new NotImplementedException();
        }
    }
}
