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
    public class OrdersItemsController : Controller
    {
        private IOrdersItemsRepository ordersItemsRepository;

        public OrdersItemsController(IOrdersItemsRepository ordersItemsRepo)
        {
            ordersItemsRepository = ordersItemsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await ordersItemsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Order());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderItem orderItem)
        {
            await ordersItemsRepository.Create(orderItem);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await ordersItemsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await ordersItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderItem orderItem)
        {
            await ordersItemsRepository.Update(orderItem);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await ordersItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrderItem orderItem)
        {
            await ordersItemsRepository.Delete(orderItem);
            return RedirectToAction("Index");
        }
    }
}