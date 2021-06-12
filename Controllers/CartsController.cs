using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    public class CartsController : Controller
    {
        private ICartsRepository cartsRepository;

        public CartsController(ICartsRepository cartsRepo)
        {
            cartsRepository = cartsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await cartsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Cart());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            await cartsRepository.Create(cart);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Find(long id)
        {
            return View(await cartsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await cartsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Cart cart)
        {
            await cartsRepository.Update(cart);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await cartsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cart cart)
        {
            await cartsRepository.Delete(cart);
            return RedirectToAction("Index");
        }
    }
}