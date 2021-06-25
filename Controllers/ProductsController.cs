using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsRepository productsRepository;

        private ICategoriesRepository categoriesRepository;
        private IManufacturersRepository manufacturersRepository;
        private IProductsKindsRepository productsKindsRepository;

        public ProductsController(IProductsRepository productsRepo,
            ICategoriesRepository categoriesRepo,
            IManufacturersRepository manufacturersRepo,
            IProductsKindsRepository productsKindsRepo)
        {
            productsRepository = productsRepo;
            categoriesRepository = categoriesRepo;
            manufacturersRepository = manufacturersRepo;
            productsKindsRepository = productsKindsRepo;
        }

        [Route("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return View(await productsRepository.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await categoriesRepository.GetAll(), "Id", "CategoryName");
            ViewBag.Manufacturers = new SelectList(await manufacturersRepository.GetAll(), "Id", "ManufacturerName");
            ViewBag.ProductsKinds = new SelectList(await productsKindsRepository.GetAll(), "Id", "KindName");
            return View(new Product());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await productsRepository.Create(product);
                return RedirectToAction("GetAllProducts");
            }
            else return View(product);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await productsRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            ViewBag.Categories = new SelectList(await categoriesRepository.GetAll(), "Id", "CategoryName");
            ViewBag.Manufacturers = new SelectList(await manufacturersRepository.GetAll(), "Id", "ManufacturerName");
            ViewBag.ProductsKinds = new SelectList(await productsKindsRepository.GetAll(), "Id", "KindName");
            return View(await productsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await productsRepository.Create(product);
                return RedirectToAction("GetAllProducts");
            }
            else return View(product);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await productsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await productsRepository.Delete(product);
            return RedirectToAction("GetAllProducts");
        }
    }
}
