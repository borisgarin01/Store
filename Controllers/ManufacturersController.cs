using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    public class ManufacturersController : Controller
    {
        private IManufacturersRepository manufacturersRepository;

        public ManufacturersController(IManufacturersRepository manufacturersRepo)
        {
            manufacturersRepository = manufacturersRepo;
        }

        public async Task<IActionResult> Index()
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
            await manufacturersRepository.Create(manufacturer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await manufacturersRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await manufacturersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Manufacturer manufacturer)
        {
            await manufacturersRepository.Update(manufacturer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await manufacturersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Manufacturer manufacturer)
        {
            await manufacturersRepository.Delete(manufacturer);
            return RedirectToAction("Index");
        }
    }
}