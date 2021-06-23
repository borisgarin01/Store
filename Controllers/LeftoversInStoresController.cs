using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class LeftoversInStoresController : Controller
    {
        private StoreContext storeContext;

        public LeftoversInStoresController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("LeftoversInStores")]
        public async Task<IActionResult> GetAllLeftoversInStores()
        {
            return View(await storeContext.LeftoversInStores.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new LeftoversInStore());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeftoversInStore leftoversInStore)
        {
            if (ModelState.IsValid)
            {
                storeContext.LeftoversInStores.Add(leftoversInStore);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(leftoversInStore);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.LeftoversInStores.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.LeftoversInStores.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LeftoversInStore leftoversInStore)
        {
            if (ModelState.IsValid)
            {
                storeContext.LeftoversInStores.Update(leftoversInStore);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllLeftoversInStores");
            }
            else return View(leftoversInStore);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.LeftoversInStores.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LeftoversInStore leftoversInStore)
        {
                storeContext.LeftoversInStores.Remove(leftoversInStore);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllLeftoversInStores");
        }
    }
}
