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
    public class ClientsAPIController : ControllerBase
    {
        private IClientsRepository clientsRepository;

        public ClientsAPIController(IClientsRepository clientsRepo)
        {
            clientsRepository = clientsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await clientsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Client client = await clientsRepository.Get(id);
            if (client != null)
            {
                return Ok(client);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Client client = await clientsRepository.Get(id);
            if (client != null)
            {
                await clientsRepository.Update(client);
            }
            return Ok(clientsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            await clientsRepository.Create(client);
            return Ok(clientsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Client client = await clientsRepository.Get(id);
            if (client != null)
            {
                await clientsRepository.Delete(client);
            }
            return Ok(clientsRepository.GetAll());
        }
    }
}