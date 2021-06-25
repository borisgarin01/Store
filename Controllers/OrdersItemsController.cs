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
    public class OrdersItemsController : Controller
    {
        private IOrdersItemsRepository ordersItemsRepository;
        private IOrdersRepository ordersRepository;
        private IProductsRepository productsRepository;

        public OrdersItemsController(IOrdersItemsRepository ordersItemsRepo,
            IOrdersRepository ordersRepo,
            IProductsRepository productsRepo)
        {
            ordersItemsRepository = ordersItemsRepo;
            ordersRepository = ordersRepo;
            productsRepository = productsRepo;
        }

        [Route("OrdersItems")]
        public async Task<IActionResult> GetAllOrdersItems()
        {
            return View(await ordersItemsRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Orders = new SelectList(await ordersRepository.GetAll(), "Id", "OrderingDate");
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");

            return View(new OrdersItem());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdersItem ordersItem)
        {
            if (ModelState.IsValid)
            {
                await ordersItemsRepository.Create(ordersItem);
                return RedirectToAction("Index");
            }
            else return View(ordersItem);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await ordersItemsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Orders = new SelectList(await ordersRepository.GetAll(), "Id", "OrderingDate");
            ViewBag.Products = new SelectList(await productsRepository.GetAll(), "Id", "ProductName");

            return View(await ordersRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrdersItem ordersItem)
        {
            if (ModelState.IsValid)
            {
                await ordersItemsRepository.Update(ordersItem);
                return RedirectToAction("GetAllOrdersItems");
            }
            else return View(ordersItem);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await ordersItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrdersItem ordersItem)
        {
            await ordersItemsRepository.Delete(ordersItem);
            return RedirectToAction("GetAllOrdersItems");
        }
    }
}
