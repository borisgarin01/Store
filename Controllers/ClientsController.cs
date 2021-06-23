using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ClientsController : Controller
    {
        private StoreContext storeContext;

        public ClientsController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Clients")]
        public async Task<IActionResult> GetAllClients()
        {
            return View(await storeContext.Clients.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Client());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                storeContext.Clients.Add(client);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(client);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Clients.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.Clients.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                storeContext.Clients.Update(client);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClients");
            }
            else return View(client);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Clients.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Client client)
        {
                storeContext.Clients.Remove(client);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClients");
        }
    }
}
