using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Store.Data;
using Store.Helpers;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class BuyController : Controller
    {
        private ICartsRepository cartsRepository;
        private IProductsRepository productsRepository;
        private ICartsItemsRepository cartsItemsRepository;

        public BuyController(ICartsRepository cartsRepo,IProductsRepository productsRepo,
            ICartsItemsRepository cartsItemsRepo)
        {
            cartsRepository = cartsRepo;
            productsRepository = productsRepo;
            cartsItemsRepository = cartsItemsRepo;
        }

        public async Task<IActionResult> GetAllProducts()
        {
            return View(await productsRepository.GetAll());
        }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<StoreContext>();
            string cartId = session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new Cart(context) { Id = Convert.ToInt64(cartId) };
        }

        public void AddToCart(Product product, Cart cart,short quantity, IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<StoreContext>();
            cart.CartsItems.Add(new CartsItem { Cart = cart, Product = product, Quantity = quantity });
            session.SetObjectAsJson("cart"+session, cart);
        }
    }
}
