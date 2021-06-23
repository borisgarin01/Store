using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ClientsAddressesController : Controller
    {
        private StoreContext storeContext;

        public ClientsAddressesController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("ClientsAddresses")]
        public async Task<IActionResult> GetAllClientsAddresses()
        {
            return View(await storeContext.ClientsAddresses.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new ClientsAddress());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientsAddress clientsAddress)
        {
            if (ModelState.IsValid)
            {
                storeContext.ClientsAddresses.Add(clientsAddress);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(clientsAddress);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.ClientsAddresses.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.ClientsAddresses.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientsAddress clientsAddress)
        {
            if (ModelState.IsValid)
            {
                storeContext.ClientsAddresses.Update(clientsAddress);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClientsAddresses");
            }
            else return View(clientsAddress);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.ClientsAddresses.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ClientsAddress clientsAddress)
        {
                storeContext.ClientsAddresses.Remove(clientsAddress);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllClientsAddresses");
        }
    }
}
