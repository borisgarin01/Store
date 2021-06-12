using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Models;

namespace Store.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Category>> GetAll();
        public Task Create(Category category);
        public Task<Category> Get(long id);
        public Task Update(Category category);
        public Task Delete(Category category);
    }
}
