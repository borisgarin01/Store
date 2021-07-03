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
    [Route("api/Carts")]
    public class CartsAPIController : ControllerBase
    {
        private ICartsRepository cartsRepository;

        public CartsAPIController(ICartsRepository cartsRepo)
        {
            cartsRepository = cartsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Cart>> Get()
        {
            return await cartsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> Get(int id)
        {
            return new ObjectResult(await cartsRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> Post(Cart cart)
        {
            if (cart == null)
            {
                return BadRequest();
            }
            else
            {
                await cartsRepository.Create(cart);
                return Ok(cart);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Cart>> Put(Cart cart)
        {
            if (cart == null)
            {
                return BadRequest();
            }
            else
            {
                await cartsRepository.Update(cart);
                return Ok(cart);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> Delete(long id)
        {
            Cart cart = await cartsRepository.Get(id);
            if (cart == null)
            {
                return NotFound();
            }
            else
            {
                await cartsRepository.Delete(cart);
                return Ok(cart);
            }
        }
    }
}
