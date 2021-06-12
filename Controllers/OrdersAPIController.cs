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
    public class OrdersAPIController : ControllerBase
    {
        private IOrdersRepository ordersRepository;

        public OrdersAPIController(IOrdersRepository ordersRepo)
        {
            ordersRepository = ordersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await ordersRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Order order = await ordersRepository.Get(id);
            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Order order = await ordersRepository.Get(id);
            if (order != null)
            {
                await ordersRepository.Update(order);
            }
            return Ok(ordersRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            await ordersRepository.Create(order);
            return Ok(ordersRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Order order = await ordersRepository.Get(id);
            if (order != null)
            {
                await ordersRepository.Delete(order);
            }
            return Ok(ordersRepository.GetAll());
        }
    }
}