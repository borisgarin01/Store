using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ProductsKindsController : Controller
    {
        private IProductsKindsRepository productsKindsRepository;

        public ProductsKindsController(IProductsKindsRepository productsKindsRepo)
        {
            productsKindsRepository = productsKindsRepo;
        }

        [Route("ProductsKinds")]
        public async Task<IActionResult> GetAllProductsKinds()
        {
            return View(await productsKindsRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new ProductsKind());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductsKind productsKind)
        {
            if (ModelState.IsValid)
            {
                await productsKindsRepository.Create(productsKind);
                return RedirectToAction("Index");
            }
            else return View(productsKind);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await productsKindsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await productsKindsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductsKind productsKind)
        {
            if (ModelState.IsValid)
            {
                await productsKindsRepository.Update(productsKind);
                return RedirectToAction("GetAllProductsKinds");
            }
            else return View(productsKind);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await productsKindsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductsKind productsKind)
        {
            await productsKindsRepository.Delete(productsKind);
            return RedirectToAction("GetAllProductsKinds");
        }
    }
}
