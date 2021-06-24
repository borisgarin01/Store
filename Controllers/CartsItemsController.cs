using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class CartsItemsController : Controller
    {
        private StoreContext storeContext;

        public CartsItemsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("CartsItems")]
        public async Task<IActionResult> GetAllCartsItems()
        {
            return View(await storeContext.CartsItems.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Carts = new SelectList(await storeContext.Carts.ToListAsync(), "Id", "ClientId");
            ViewBag.Products = new SelectList(await storeContext.Products.ToListAsync(), "Id", "ProductName");
            return View(new CartsItem());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartsItem cartsItem)
        {
            if (ModelState.IsValid)
            {
                storeContext.CartsItems.Add(cartsItem);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(cartsItem);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.CartsItems.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Carts = new SelectList(await storeContext.Carts.ToListAsync(), "Id", "ClientId");
            ViewBag.Products = new SelectList(await storeContext.Products.ToListAsync(), "Id", "ProductName");
            return View(await storeContext.CartsItems.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CartsItem cartsItem)
        {
            if (ModelState.IsValid)
            {
                storeContext.CartsItems.Update(cartsItem);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllCartsItems");
            }
            else return View(cartsItem);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.CartsItems.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CartsItem cartsItem)
        {
                storeContext.CartsItems.Remove(cartsItem);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllCartsItems");
        }
    }
}
