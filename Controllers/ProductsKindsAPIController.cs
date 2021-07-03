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
    [Route("api/ProductsKinds")]
    public class ProductsKindsAPIController : ControllerBase
    {
        private IProductsKindsRepository productsKindsRepository;

        public ProductsKindsAPIController(IProductsKindsRepository productsKindsRepo)
        {
            productsKindsRepository = productsKindsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductsKind>> Get()
        {
            return await productsKindsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsKind>> Get(int id)
        {
            return new ObjectResult(await productsKindsRepository.Get(id));
        }





        [HttpPost]
        public async Task<ActionResult<ProductsKind>> Post(ProductsKind productsKind)
        {
            if (productsKind == null)
            {
                return BadRequest();
            }
            else
            {
                await productsKindsRepository.Create(productsKind);
                return Ok(productsKind);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductsKind>> Put(ProductsKind productsKind)
        {
            if (productsKind == null)
            {
                return BadRequest();
            }
            else
            {
                await productsKindsRepository.Update(productsKind);
                return Ok(productsKind);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(long id)
        {
            ProductsKind productsKind = await productsKindsRepository.Get(id);
            if (productsKind == null)
            {
                return NotFound();
            }
            else
            {
                await productsKindsRepository.Delete(productsKind);
                return Ok(productsKind);
            }
        }
    }
}
