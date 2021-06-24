using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ClientsPhonesNumbersController : Controller
    {
        private StoreContext storeContext;

        public ClientsPhonesNumbersController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("ClientsPhonesNumbers")]
        public async Task<IActionResult> GetAllClientsPhonesNumbers()
        {
            return View(await storeContext.ClientsPhonesNumbers.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await storeContext.Clients.ToListAsync();
            return View(new ClientsPhonesNumber());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientsPhonesNumber clientsPhonesNumber)
        {
            if (ModelState.IsValid)
            {
                storeContext.ClientsPhonesNumbers.Add(clientsPhonesNumber);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(clientsPhonesNumber);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.ClientsPhonesNumbers.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Clients = await storeContext.Clients.ToListAsync();
            return View(await storeContext.ClientsPhonesNumbers.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientsPhonesNumber clientsPhonesNumber)
        {
            if (ModelState.IsValid)
            {
                storeContext.ClientsPhonesNumbers.Update(clientsPhonesNumber);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClientsPhonesNumbers");
            }
            else return View(clientsPhonesNumber);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.ClientsPhonesNumbers.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientsPhonesNumber clientsPhonesNumber)
        {
                storeContext.ClientsPhonesNumbers.Remove(clientsPhonesNumber);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClientsPhonesNumbers");
        }
    }
}
