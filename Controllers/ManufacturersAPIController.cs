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
    public class ManufacturersAPIController : ControllerBase
    {
        private IManufacturersRepository manufacturersRepository;

        public ManufacturersAPIController(IManufacturersRepository manufacturersRepo)
        {
            manufacturersRepository = manufacturersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await manufacturersRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Manufacturer manufacturer = await manufacturersRepository.Get(id);
            if (manufacturer != null)
            {
                return Ok(manufacturer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Manufacturer manufacturer = await manufacturersRepository.Get(id);
            if (manufacturer != null)
            {
                await manufacturersRepository.Update(manufacturer);
            }
            return Ok(manufacturersRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            await manufacturersRepository.Create(manufacturer);
            return Ok(manufacturersRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Manufacturer manufacturer = await manufacturersRepository.Get(id);
            if (manufacturer != null)
            {
                await manufacturersRepository.Delete(manufacturer);
            }
            return Ok(manufacturersRepository.GetAll());
        }
    }
}