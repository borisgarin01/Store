using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class StoresController : Controller
    {
        private IStoresRepository storesRepository;
        private IAddressesRepository addressesRepository;

        public StoresController(IStoresRepository storesRepo,
            IAddressesRepository addressesRepo)
        {
            storesRepository = storesRepo;
            addressesRepository = addressesRepo;
        }

        [Route("Stores")]
        public async Task<IActionResult> GetAllStores()
        {
            return View(await storesRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Addresses =await addressesRepository.GetAll();
            return View(new Models.Store());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Store store)
        {
            if (ModelState.IsValid)
            {
                await storesRepository.Create(store);
                return RedirectToAction("Index");
            }
            else return View(store);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storesRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Addresses = await addressesRepository.GetAll();
            return View(await storesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Store store)
        {
            if (ModelState.IsValid)
            {
                await storesRepository.Update(store);
                return RedirectToAction("GetAllStores");
            }
            else return View(store);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Models.Store store)
        {
            await storesRepository.Delete(store);
            return RedirectToAction("GetAllStores");
        }
    }
}
