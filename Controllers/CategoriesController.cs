using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class CategoriesController : Controller
    {
        private StoreContext storeContext;

        public CategoriesController(StoreContext context)
        {
            storeContext = context;
        }

        [Route("Categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return View(await storeContext.Categories.ToListAsync());
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
                storeContext.Categories.Add(category);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else return View(category);
        }

        public async Task<IActionResult> Get(long id)
        {
            return View(await storeContext.Categories.FirstAsync(a => a.Id == id));
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await storeContext.Categories.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                storeContext.Categories.Update(category);
                await storeContext.SaveChangesAsync();
                return RedirectToAction("GetAllCategories");
            }
            else return View(category);
        }

        public async Task<IActionResult> Delete(long id)
        {
            return View(await storeContext.Categories.FirstAsync(a => a.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Category category)
        {
            storeContext.Products.RemoveRange(storeContext.Products.Where(p => p.CategoryId == category.Id));
            storeContext.Categories.Remove(category);
            await storeContext.SaveChangesAsync();
            return RedirectToAction("GetAllCategories");
        }
    }
}
