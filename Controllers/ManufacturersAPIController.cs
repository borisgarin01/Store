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
    [Route("api/Manufacturers")]
    public class ManufacturersAPIController : ControllerBase
    {
        private IManufacturersRepository manufacturersRepository;

        public ManufacturersAPIController(IManufacturersRepository manufacturersRepo)
        {
            manufacturersRepository = manufacturersRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Manufacturer>> Get()
        {
            return await manufacturersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> Get(int id)
        {
            return new ObjectResult(await manufacturersRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Manufacturer>> Post(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return BadRequest();
            }
            else
            {
                await manufacturersRepository.Create(manufacturer);
                return Ok(manufacturer);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Manufacturer>> Put(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return BadRequest();
            }
            else
            {
                await manufacturersRepository.Update(manufacturer);
                return Ok(manufacturer);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Manufacturer>> Delete(long id)
        {
            Manufacturer manufacturer = await manufacturersRepository.Get(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            else
            {
                await manufacturersRepository.Delete(manufacturer);
                return Ok(manufacturer);
            }
        }
    }
}
