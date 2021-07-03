using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/Categories")]
    public class CategoriesAPIController : ControllerBase
    {
        private ICategoriesRepository categoriesRepository;

        public CategoriesAPIController(ICategoriesRepository categoriesRepo)
        {
            categoriesRepository = categoriesRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await categoriesRepository.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            return new ObjectResult(await categoriesRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            else
            {
                await categoriesRepository.Create(category);
                return Ok(category);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Category>> Put(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            else
            {
                await categoriesRepository.Update(category);
                return Ok(category);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> Delete(long id)
        {
            Category category = await categoriesRepository.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                await categoriesRepository.Delete(category);
                return Ok(category);
            }
        }
    }
}
