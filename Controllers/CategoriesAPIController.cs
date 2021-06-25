using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class CategoriesAPIController : ControllerBase
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesAPIController(ICategoriesRepository categoriesRepo)
        {
            categoriesRepository = categoriesRepo;
        }
    }
}
