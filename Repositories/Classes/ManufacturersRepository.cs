using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class ManufacturersRepository:IManufacturersRepository
    {
        public ManufacturersRepository()
        {
        }

        public Task Create(Manufacturer item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Manufacturer item)
        {
            throw new NotImplementedException();
        }

        public Task<Manufacturer> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manufacturer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Manufacturer item)
        {
            throw new NotImplementedException();
        }
    }
}
