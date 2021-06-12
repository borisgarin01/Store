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
    public class AddressesAPIController : ControllerBase
    {
        private IAddressesRepository addressesRepository;

        public AddressesAPIController(IAddressesRepository addressesRepo)
        {
            addressesRepository = addressesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await addressesRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult>Get(long id)
        {
            Address address = await addressesRepository.Get(id);
            if (address != null)
            {
                return Ok(address);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Address address = await addressesRepository.Get(id);
            if (address != null)
            {
                await addressesRepository.Update(address);
            }
            return Ok(addressesRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Address address)
        {
            await addressesRepository.Create(address);
            return Ok(addressesRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult>Delete(long id)
        {
            Address address = await addressesRepository.Get(id);
            if (address != null)
            {
                await addressesRepository.Delete(address);
            }
            return Ok(addressesRepository.GetAll());
        }
    }
}
