using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface IManufacturersRepository
    {
        public Task<IEnumerable<Manufacturer>> GetAll();
        public Task Create(Manufacturer manufacturer);
        public Task<Manufacturer> Get(long id);
        public Task Update(Manufacturer manufacturer);
        public Task Delete(Manufacturer manufacturer);
    }
}
