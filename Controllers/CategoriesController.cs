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
    public class CategoriesController : Controller
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepo)
        {
            categoriesRepository = categoriesRepo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await categoriesRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Category());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await categoriesRepository.Create(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Find(long id)
        {
            return View(await categoriesRepository.Get(id));
        }

        public async Task<IActionResult> Update(long id)
        {
            return View(await categoriesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            await categoriesRepository.Update(category);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await categoriesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            await categoriesRepository.Delete(category);
            return RedirectToAction("Index");
        }
    }
}