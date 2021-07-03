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
    [Route("api/OrdersItems")]
    public class OrdersItemsAPIController : ControllerBase
    {
        private IOrdersItemsRepository ordersItemsRepository;

        public OrdersItemsAPIController(IOrdersItemsRepository ordersItemsRepo)
        {
            ordersItemsRepository = ordersItemsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<OrdersItem>> Get()
        {
            return await ordersItemsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersItem>> Get(int id)
        {
            return new ObjectResult(await ordersItemsRepository.Get(id));
        }


        [HttpPost]
        public async Task<ActionResult<OrdersItem>> Post(OrdersItem ordersItem)
        {
            if (ordersItem == null)
            {
                return BadRequest();
            }
            else
            {
                await ordersItemsRepository.Create(ordersItem);
                return Ok(ordersItem);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrdersItem>> Put(OrdersItem ordersItem)
        {
            if (ordersItem == null)
            {
                return BadRequest();
            }
            else
            {
                await ordersItemsRepository.Update(ordersItem);
                return Ok(ordersItem);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersItem>> Delete(long id)
        {
            OrdersItem ordersItem = await ordersItemsRepository.Get(id);
            if (ordersItem == null)
            {
                return NotFound();
            }
            else
            {
                await ordersItemsRepository.Delete(ordersItem);
                return Ok(ordersItem);
            }
        }
    }
}
