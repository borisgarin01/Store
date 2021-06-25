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
    public class CartsItemsController : Controller
    {
        private ICartsItemsRepository cartsItemsRepository;
        private ICartsRepository cartsRepository;
        private IProductsRepository productsRepository;

        public CartsItemsController(ICartsItemsRepository cartsItemsRepo,
            ICartsRepository cartsRepo,
            IProductsRepository productsRepo)
        {
            cartsItemsRepository = cartsItemsRepo;
            cartsRepository = cartsRepo;
            productsRepository = productsRepo;
        }

        [Route("CartsItems")]
        public async Task<IActionResult> GetAllCartsItems()
        {
            return View(await cartsItemsRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Carts = new SelectList(await cartsRepository.GetAll(), "Id", "ClientId");
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");
            return View(new CartsItem());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartsItem cartsItem)
        {
            if (ModelState.IsValid)
            {
                await cartsItemsRepository.Create(cartsItem);
                return RedirectToAction("Index");
            }
            else return View(cartsItem);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await cartsItemsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Carts = new SelectList(await cartsRepository.GetAll(), "Id", "ClientId");
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");
            return View(await cartsItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CartsItem cartsItem)
        {
            if (ModelState.IsValid)
            {
                await cartsItemsRepository.Update(cartsItem);
                return RedirectToAction("GetAllCartsItems");
            }
            else return View(cartsItem);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await cartsItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CartsItem cartsItem)
        {
            await cartsItemsRepository.Delete(cartsItem);
            return RedirectToAction("GetAllCartsItems");
        }
    }
}
