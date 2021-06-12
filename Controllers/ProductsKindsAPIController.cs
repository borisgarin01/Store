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
    public class ProductsKindsAPIController : ControllerBase
    {
        private IProductsKindsRepository productsKindsRepository;

        public ProductsKindsAPIController(IProductsKindsRepository productsKindsRepo)
        {
            productsKindsRepository = productsKindsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productsKindsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            ProductKind productKind = await productsKindsRepository.Get(id);
            if (productKind != null)
            {
                return Ok(productKind);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            ProductKind productKind = await productsKindsRepository.Get(id);
            if (productKind != null)
            {
                await productsKindsRepository.Update(productKind);
            }
            return Ok(productsKindsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductKind productKind)
        {
            await productsKindsRepository.Create(productKind);
            return Ok(productsKindsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            ProductKind productKind = await productsKindsRepository.Get(id);
            if (productKind != null)
            {
                await productsKindsRepository.Delete(productKind);
            }
            return Ok(productsKindsRepository.GetAll());
        }
    }
}
