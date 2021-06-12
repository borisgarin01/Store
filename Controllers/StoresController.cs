using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    public class StoresController : Controller
    {
        private IStoresRepository storesRepository;

        public StoresController(IStoresRepository storesRepo)
        {
            storesRepository = storesRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await storesRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Models.Store());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Store store)
        {
            await storesRepository.Create(store);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await storesRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await storesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.Store store)
        {
            await storesRepository.Update(store);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Models.Store store)
        {
            await storesRepository.Delete(store);
            return RedirectToAction("Index");
        }
    }
}