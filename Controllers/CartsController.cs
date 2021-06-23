using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class CartsController : Controller
    {
        private StoreContext storeContext;

        public CartsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Carts")]
        public async Task<IActionResult> GetAllCarts()
        {
            return View(await storeContext.Carts.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Cart());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                storeContext.Carts.Add(cart);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(cart);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Carts.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.Carts.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                storeContext.Carts.Update(cart);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllCarts");
            }
            else return View(cart);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Carts.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cart cart)
        {
            storeContext.Carts.Remove(cart);
            await storeContext.SaveChangesAsync();
            return RedirectToAction("GetAllCarts");
        }
    }
}
