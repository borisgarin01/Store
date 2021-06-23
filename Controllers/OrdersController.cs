using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class OrdersController : Controller
    {
        private StoreContext storeContext;

        public OrdersController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return View(await storeContext.Orders.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Order());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                storeContext.Orders.Add(order);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(order);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Orders.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.Orders.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                storeContext.Orders.Update(order);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllOrders");
            }
            else return View(order);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Orders.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Order order)
        {
                storeContext.Orders.Remove(order);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllOrders");
        }
    }
}
