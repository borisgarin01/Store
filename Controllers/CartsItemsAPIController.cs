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
    public class CartsItemsAPIController : ControllerBase
    {
        private ICartsItemsRepository cartsItemsRepository;

        public CartsItemsAPIController(ICartsItemsRepository cartsItemsRepo)
        {
            cartsItemsRepository = cartsItemsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await cartsItemsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            CartItem cartItem = await cartsItemsRepository.Get(id);
            if (cartItem != null)
            {
                return Ok(cartItem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            CartItem cartItem = await cartsItemsRepository.Get(id);
            if (cartItem != null)
            {
                await cartsItemsRepository.Update(cartItem);
            }
            return Ok(cartsItemsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CartItem cartItem)
        {
            await cartsItemsRepository.Create(cartItem);
            return Ok(cartsItemsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            CartItem cartItem = await cartsItemsRepository.Get(id);
            if (cartItem != null)
            {
                await cartsItemsRepository.Delete(cartItem);
            }
            return Ok(cartsItemsRepository.GetAll());
        }
    }
}
