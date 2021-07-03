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
    [Route("api/ClientsAddresses")]
    public class ClientsAddressesAPIController : ControllerBase
    {
        private IClientsAddressesRepository clientsAddressesRepository;

        public ClientsAddressesAPIController(IClientsAddressesRepository clientsAddressesRepo)
        {
            clientsAddressesRepository = clientsAddressesRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientsAddress>> Get()
        {
            return await clientsAddressesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientsAddress>> Get(int id)
        {
            return new ObjectResult(await clientsAddressesRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<ClientsAddress>> Post(ClientsAddress clientsAddress)
        {
            if (clientsAddress == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsAddressesRepository.Create(clientsAddress);
                return Ok(clientsAddress);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClientsAddress>> Put(ClientsAddress clientsAddress)
        {
            if (clientsAddress == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsAddressesRepository.Update(clientsAddress);
                return Ok(clientsAddress);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientsAddress>> Delete(long id)
        {
            ClientsAddress clientsAddress = await clientsAddressesRepository.Get(id);
            if (clientsAddress == null)
            {
                return NotFound();
            }
            else
            {
                await clientsAddressesRepository.Delete(clientsAddress);
                return Ok(clientsAddress);
            }
        }
    }
}
