using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class AddressesController:Controller
    {
        private StoreContext storeContext;

        public AddressesController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Addresses")]
        public async Task<IActionResult> GetAllAddresses()
        {
            return View(await storeContext.Addresses.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Address());
        }

        [HttpPost]
        public async Task<IActionResult>Create(Address address)
        {
            if (ModelState.IsValid)
            {
                storeContext.Addresses.Add(address);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(address);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Addresses.FirstAsync(a=>a.Id==id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.Addresses.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                storeContext.Addresses.Update(address);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllAddresses");
            }
            else return View(address);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Addresses.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Address address)
        {

            storeContext.Addresses.Remove(address);
            await storeContext.SaveChangesAsync();
            return RedirectToAction("GetAllAddresses");
        }
    }
}
