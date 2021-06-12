using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartsAPIController : ControllerBase
    {
        private ICartsRepository cartsRepository;

        public CartsAPIController(ICartsRepository cartsRepo)
        {
            cartsRepository = cartsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await cartsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Cart cart = await cartsRepository.Get(id);
            if (cart != null)
            {
                return Ok(cart);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Cart cart = await cartsRepository.Get(id);
            if (cart != null)
            {
                await cartsRepository.Update(cart);
            }
            return Ok(cartsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cart cart)
        {
            await cartsRepository.Create(cart);
            return Ok(cartsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Cart cart = await cartsRepository.Get(id);
            if (cart != null)
            {
                await cartsRepository.Delete(cart);
            }
            return Ok(cartsRepository.GetAll());
        }
    }
}