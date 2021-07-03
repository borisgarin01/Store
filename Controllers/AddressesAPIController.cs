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
    [Route("api/Addresses")]
    public class AddressesAPIController:ControllerBase
    {
        private IAddressesRepository addressesRepository;

        public AddressesAPIController(IAddressesRepository addressesRepo)
        {
            addressesRepository = addressesRepo;
        }
        [HttpGet]
        public async Task<IEnumerable<Address>> Get()
        {
            return await addressesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> Get(long id)
        {
            return new ObjectResult(await addressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Address>>Post(Address address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            else
            {
                await addressesRepository.Create(address);
                return Ok(address);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Address>> Put(Address address)
        {
            if (address == null)
            {
                return BadRequest();
            }
            else
            {
                await addressesRepository.Update(address);
                return Ok(address);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Address>>Delete(long id)
        {
            Address address = await addressesRepository.Get(id);
            if (address == null)
            {
                return NotFound();
            }
            else
            {
                await addressesRepository.Delete(address);
                return Ok(address);
            }
        }
    }
}
