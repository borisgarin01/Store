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
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesAPIController : ControllerBase
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesAPIController(ICategoriesRepository categoriesRepo)
        {
            categoriesRepository = categoriesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoriesRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Category category = await categoriesRepository.Get(id);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Category category = await categoriesRepository.Get(id);
            if (category != null)
            {
                await categoriesRepository.Update(category);
            }
            return Ok(categoriesRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await categoriesRepository.Create(category);
            return Ok(categoriesRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Category category = await categoriesRepository.Get(id);
            if (category != null)
            {
                await categoriesRepository.Delete(category);
            }
            return Ok(categoriesRepository.GetAll());
        }
    }
}
