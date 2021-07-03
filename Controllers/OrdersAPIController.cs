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
    [Route("api/Orders")]
    public class OrdersAPIController : ControllerBase
    {
        private IOrdersRepository ordersRepository;

        public OrdersAPIController(IOrdersRepository ordersRepo)
        {
            ordersRepository = ordersRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await ordersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            return new ObjectResult(await ordersRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            else
            {
                await ordersRepository.Create(order);
                return Ok(order);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Order>> Put(Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            else
            {
                await ordersRepository.Update(order);
                return Ok(order);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> Delete(long id)
        {
            Order order = await ordersRepository.Get(id);
            if (order == null)
            {
                return NotFound();
            }
            else
            {
                await ordersRepository.Delete(order);
                return Ok(order);
            }
        }
    }
}
