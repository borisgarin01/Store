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
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;

        public ProductsController(IProductsRepository productsRepo)
        {
            productsRepository = productsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await productsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await productsRepository.Create(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await productsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await productsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            await productsRepository.Update(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await productsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await productsRepository.Delete(product);
            return RedirectToAction("Index");
        }
    }
}