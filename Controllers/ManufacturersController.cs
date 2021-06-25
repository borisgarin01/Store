using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ManufacturersController : Controller
    {
        private IManufacturersRepository manufacturersRepository;

        public ManufacturersController(IManufacturersRepository manufacturersRepo)
        {
            manufacturersRepository = manufacturersRepo;
        }

        [Route("Manufacturers")]
        public async Task<IActionResult> GetAllManufacturers()
        {
            return View(await manufacturersRepository.GetAll());
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
                await manufacturersRepository.Create(manufacturer);
                return RedirectToAction("Index");
            }
            else return View(manufacturer);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await manufacturersRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await manufacturersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                await manufacturersRepository.Update(manufacturer);
                return RedirectToAction("GetAllManufacturers");
            }
            else return View(manufacturer);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await manufacturersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Manufacturer manufacturer)
        {
            await manufacturersRepository.Delete(manufacturer);
            return RedirectToAction("GetAllManufacturers");
        }
    }
}
