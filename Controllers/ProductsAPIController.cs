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
    [Route("api/Products")]
    public class ProductsAPIController : ControllerBase
    {
        private IProductsRepository productsRepository;

        public ProductsAPIController(IProductsRepository productsRepo)
        {
            productsRepository = productsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await productsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            return new ObjectResult(await productsRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                await productsRepository.Create(product);
                return Ok(product);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            else
            {
                await productsRepository.Update(product);
                return Ok(product);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(long id)
        {
            Product product = await productsRepository.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                await productsRepository.Delete(product);
                return Ok(product);
            }
        }
    }
}
