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
    public class CartsItemsController : Controller
    {
        private ICartsItemsRepository cartsItemsRepository;

        public CartsItemsController(ICartsItemsRepository cartsItemsRepo)
        {
            cartsItemsRepository = cartsItemsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await cartsItemsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new CartItem());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartItem cartItem)
        {
            await cartsItemsRepository.Create(cartItem);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await cartsItemsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await cartsItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(CartItem cartItem)
        {
            await cartsItemsRepository.Update(cartItem);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await cartsItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CartItem cartItem)
        {
            await cartsItemsRepository.Delete(cartItem);
            return RedirectToAction("Index");
        }
    }
}