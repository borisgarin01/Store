using System;
using System.Threading.Tasks;
using Store.Models;
using Store.Repositories.Interfaces.Base;

namespace Store.Repositories.Interfaces
{
    public interface ICartsItemsRepository : IRepository<CartsItem>
    {
        public Task AddCartItemQuantity(CartsItem cartsItem);
    }
}
