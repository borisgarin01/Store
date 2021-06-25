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
    public class LeftoversInStoresController : Controller
    {
        private ILeftoversInStoresRepository leftoversInStoresRepository;
        private IProductsRepository productsRepository;
        private IStoresRepository storesRepository;

        public LeftoversInStoresController(ILeftoversInStoresRepository leftoversInStoresRepo,
            IProductsRepository productsRepo,
            IStoresRepository storesRepo)
        {
            leftoversInStoresRepository = leftoversInStoresRepo;
            productsRepository = productsRepo;
            storesRepository = storesRepo;
        }

        [Route("LeftoversInStores")]
        public async Task<IActionResult> GetAllLeftoversInStores()
        {
            return View(await leftoversInStoresRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");
            ViewBag.Stores = new SelectList(await storesRepository.GetAll(), "Id", "AddressId");

            return View(new LeftoversInStore());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeftoversInStore leftoversInStore)
        {
            if (ModelState.IsValid)
            {
                await leftoversInStoresRepository.Create(leftoversInStore);
                return RedirectToAction("Index");
            }
            else return View(leftoversInStore);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await leftoversInStoresRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");
            ViewBag.Stores = new SelectList(await storesRepository.GetAll(), "Id", "Id");

            return View(await leftoversInStoresRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LeftoversInStore leftoversInStore)
        {
            if (ModelState.IsValid)
            {
                await leftoversInStoresRepository.Update(leftoversInStore);
                return RedirectToAction("GetAllLeftoversInStores");
            }
            else return View(leftoversInStore);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await leftoversInStoresRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LeftoversInStore leftoversInStore)
        {
            await leftoversInStoresRepository.Delete(leftoversInStore);
            return RedirectToAction("GetAllLeftoversInStores");
        }
    }
}
