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
    [Route("api/Clients")]
    public class ClientsAPIController : ControllerBase
    {
        private IClientsRepository clientsRepository;

        public ClientsAPIController(IClientsRepository clientsRepo)
        {
            clientsRepository = clientsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await clientsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            return new ObjectResult(await clientsRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsRepository.Create(client);
                return Ok(client);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Client>> Put(Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsRepository.Update(client);
                return Ok(client);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> Delete(long id)
        {
            Client client = await clientsRepository.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
                await clientsRepository.Delete(client);
                return Ok(client);
            }
        }
    }
}
