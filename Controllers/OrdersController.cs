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
    public class OrdersController : Controller
    {
        private IOrdersRepository ordersRepository;
        private IClientsAddressesRepository clientsAddressesRepository;

        public OrdersController(IOrdersRepository ordersRepo,
            IClientsAddressesRepository clientsAddressesRepo)
        {
            ordersRepository = ordersRepo;
            clientsAddressesRepository = clientsAddressesRepo;
        }

        [Route("Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return View(await ordersRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.ClientsAddresses = new SelectList(await clientsAddressesRepository.GetAll(), "Id", "Id");
            return View(new Order());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                await ordersRepository.Create(order);
                return RedirectToAction("Index");
            }
            else return View(order);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await ordersRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.ClientsAddresses = new SelectList(await clientsAddressesRepository.GetAll(), "Id", "Id");
            return View(await ordersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                await ordersRepository.Update(order);
                return RedirectToAction("GetAllOrders");
            }
            else return View(order);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await ordersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Order order)
        {
            await ordersRepository.Delete(order);
            return RedirectToAction("GetAllOrders");
        }
    }
}
