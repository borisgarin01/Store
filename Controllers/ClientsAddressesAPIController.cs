using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsAddressesAPIController : ControllerBase
    {
        private IClientsAddressesRepository clientsAddressesRepository;

        public ClientsAddressesAPIController(IClientsAddressesRepository clientsAddressesRepo)
        {
            clientsAddressesRepository = clientsAddressesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await clientsAddressesRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            ClientAddress clientAddress = await clientsAddressesRepository.Get(id);
            if (clientAddress != null)
            {
                return Ok(clientAddress);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            ClientAddress clientAddress = await clientsAddressesRepository.Get(id);
            if (clientAddress != null)
            {
                await clientsAddressesRepository.Update(clientAddress);
            }
            return Ok(clientsAddressesRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientAddress clientAddress)
        {
            await clientsAddressesRepository.Create(clientAddress);
            return Ok(clientsAddressesRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            ClientAddress clientAddress = await clientsAddressesRepository.Get(id);
            if (clientAddress != null)
            {
                await clientsAddressesRepository.Delete(clientAddress);
            }
            return Ok(clientsAddressesRepository.GetAll());
        }
    }
}