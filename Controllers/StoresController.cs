using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class StoresController : Controller
    {
        private StoreContext storeContext;

        public StoresController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Stores")]
        public async Task<IActionResult> GetAllStores()
        {
            return View(await storeContext.Stores.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Addresses =await storeContext.Addresses.ToListAsync();
            return View(new Models.Store());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Store store)
        {
            if (ModelState.IsValid)
            {
                storeContext.Stores.Add(store);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(store);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Stores.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Addresses = await storeContext.Addresses.ToListAsync();
            return View(await storeContext.Stores.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Store store)
        {
            if (ModelState.IsValid)
            {
                storeContext.Stores.Update(store);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllStores");
            }
            else return View(store);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Stores.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Models.Store store)
        {
            storeContext.Stores.Remove(store);
            await storeContext.SaveChangesAsync();
            return RedirectToAction("GetAllStores");
        }
    }
}
