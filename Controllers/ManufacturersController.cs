using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class ManufacturersController : Controller
    {
        private StoreContext storeContext;

        public ManufacturersController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Manufacturers")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            return View(await storeContext.Manufacturers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(new Manufacturer());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                storeContext.Manufacturers.Add(manufacturer);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(manufacturer);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Manufacturers.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.Manufacturers.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                storeContext.Manufacturers.Update(manufacturer);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllManufacturers");
            }
            else return View(manufacturer);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Manufacturers.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Manufacturer manufacturer)
        {
                storeContext.Manufacturers.Remove(manufacturer);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllManufacturers");
        }
    }
}
