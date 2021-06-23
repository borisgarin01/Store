using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class OrdersItemsController : Controller
    {
        private StoreContext storeContext;

        public OrdersItemsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("OrdersItems")]
        public async Task<IActionResult> GetAllOrdersItems()
        {
            return View(await storeContext.OrdersItems.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new OrdersItem());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdersItem ordersItem)
        {
            if (ModelState.IsValid)
            {
                storeContext.OrdersItems.Add(ordersItem);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(ordersItem);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.OrdersItems.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.OrdersItems.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrdersItem ordersItem)
        {
            if (ModelState.IsValid)
            {
                storeContext.OrdersItems.Update(ordersItem);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllOrdersItems");
            }
            else return View(ordersItem);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.OrdersItems.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrdersItem ordersItem)
        {
                storeContext.OrdersItems.Remove(ordersItem);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllOrdersItems");
        }
    }
}
