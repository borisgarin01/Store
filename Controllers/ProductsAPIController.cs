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
    public class ProductsAPIController : ControllerBase
    {
        private IProductsRepository productsRepository;

        public ProductsAPIController(IProductsRepository productsRepo)
        {
            productsRepository = productsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Product product = await productsRepository.Get(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Product product = await productsRepository.Get(id);
            if (product != null)
            {
                await productsRepository.Update(product);
            }
            return Ok(productsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await productsRepository.Create(product);
            return Ok(productsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Product product = await productsRepository.Get(id);
            if (product != null)
            {
                await productsRepository.Delete(product);
            }
            return Ok(productsRepository.GetAll());
        }
    }
}