using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepo)
        {
            categoriesRepository = categoriesRepo;
        }

        [Route("Categories")]
        public async Task<IActionResult> GetAllCategories()
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
            if (ModelState.IsValid)
            {
                await categoriesRepository.Create(category);
                return RedirectToAction("Index");
            }
            else return View(category);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await categoriesRepository.Get(id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await categoriesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await categoriesRepository.Update(category);
                return RedirectToAction("GetAllCategories");
            }
            else return View(category);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await categoriesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            await categoriesRepository.Delete(category);
            return RedirectToAction("GetAllCategories");
        }
    }
}
