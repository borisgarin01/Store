using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Repositories.Classes
{
    public class CategoriesRepository:ICategoriesRepository
    {
        public CategoriesRepository()
        {
        }

        public Task Create(Category item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
