using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    public class CategoriesNavigatorController:Controller
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesNavigatorController(ICategoriesRepository categoriesRepo)
        {
            categoriesRepository = categoriesRepo;
        }

        public async Task<IActionResult> NavigateCategories()
        {
            return View(await categoriesRepository.GetAll());
        }
    }
}
