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
    public class ProductsKindsController : Controller
    {
        private IProductsKindsRepository productsKindsRepository;

        public ProductsKindsController(IProductsKindsRepository productsKindsRepo)
        {
            productsKindsRepository = productsKindsRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await productsKindsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new ProductKind());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductKind productKind)
        {
            await productsKindsRepository.Create(productKind);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await productsKindsRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await productsKindsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductKind productKind)
        {
            await productsKindsRepository.Update(productKind);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await productsKindsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductKind productKind)
        {
            await productsKindsRepository.Delete(productKind);
            return RedirectToAction("Index");
        }
    }
}