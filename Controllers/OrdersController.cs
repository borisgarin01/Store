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
    public class OrdersController : Controller
    {
        private IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepo)
        {
            ordersRepository = ordersRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await ordersRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Order());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await ordersRepository.Create(order);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await ordersRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await ordersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Order order)
        {
            await ordersRepository.Update(order);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await ordersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Order order)
        {
            await ordersRepository.Delete(order);
            return RedirectToAction("Index");
        }
    }
}