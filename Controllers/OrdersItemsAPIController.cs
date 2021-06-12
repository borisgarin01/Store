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
    public class OrdersItemsAPIController : ControllerBase
    {
        private IOrdersItemsRepository ordersItemsRepository;

        public OrdersItemsAPIController(IOrdersItemsRepository ordersItemsRepo)
        {
            ordersItemsRepository = ordersItemsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await ordersItemsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            OrderItem orderItem = await ordersItemsRepository.Get(id);
            if (orderItem != null)
            {
                return Ok(orderItem);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            OrderItem orderItem = await ordersItemsRepository.Get(id);
            if (orderItem != null)
            {
                await ordersItemsRepository.Update(orderItem);
            }
            return Ok(ordersItemsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderItem orderItem)
        {
            await ordersItemsRepository.Create(orderItem);
            return Ok(ordersItemsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            OrderItem orderItem = await ordersItemsRepository.Get(id);
            if (orderItem != null)
            {
                await ordersItemsRepository.Delete(orderItem);
            }
            return Ok(ordersItemsRepository.GetAll());
        }
    }
}