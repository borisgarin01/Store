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
    [Route("api/CartsItems")]
    public class CartsItemsAPIController : ControllerBase
    {
        private ICartsItemsRepository cartsItemsRepository;

        public CartsItemsAPIController(ICartsItemsRepository cartsItemsRepo)
        {
            cartsItemsRepository = cartsItemsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CartsItem>> Get()
        {
            return await cartsItemsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartsItem>> Get(int id)
        {
            return new ObjectResult(await cartsItemsRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<CartsItem>> Post(CartsItem cartsItem)
        {
            if (cartsItem == null)
            {
                return BadRequest();
            }
            else
            {
                await cartsItemsRepository.Create(cartsItem);
                return Ok(cartsItem);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CartsItem>> Put(CartsItem cartsItem)
        {
            if (cartsItem == null)
            {
                return BadRequest();
            }
            else
            {
                await cartsItemsRepository.Update(cartsItem);
                return Ok(cartsItem);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CartsItem>> Delete(long id)
        {
            CartsItem cart = await cartsItemsRepository.Get(id);
            if (cart == null)
            {
                return NotFound();
            }
            else
            {
                await cartsItemsRepository.Delete(cart);
                return Ok(cart);
            }
        }
    }
}
