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
    public class CartsController : Controller
    {
        private ICartsRepository cartsRepository;
        private IClientsRepository clientsRepository;

        public CartsController(ICartsRepository cartsRepo,IClientsRepository clientsRepo)
        {
            cartsRepository = cartsRepo;
            clientsRepository = clientsRepo;
        }

        [Route("Carts")]
        public async Task<IActionResult> GetAllCarts()
        {
            return View(await cartsRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(new Cart());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                await cartsRepository.Create(cart);
                return RedirectToAction("Index");
            }
            else return View(cart);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await cartsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Clients = await clientsRepository.GetAll();
            return View(await cartsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                await cartsRepository.Update(cart);
                return RedirectToAction("GetAllCarts");
            }
            else return View(cart);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await cartsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cart cart)
        {
            await cartsRepository.Delete(cart);
            return RedirectToAction("GetAllCarts");
        }
    }
}
