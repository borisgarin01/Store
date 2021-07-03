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
    [Route("api/ClientsEmails")]
    public class ClientsEmailsAPIController : ControllerBase
    {
        private IClientsEmailsRepository clientsEmailsRepository;

        public ClientsEmailsAPIController(IClientsEmailsRepository clientsEmailsRepo)
        {
            clientsEmailsRepository = clientsEmailsRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientsEmail>> Get()
        {
            return await clientsEmailsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientsEmail>> Get(int id)
        {
            return new ObjectResult(await clientsEmailsRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<ClientsEmail>> Post(ClientsEmail clientsEmail)
        {
            if (clientsEmail == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsEmailsRepository.Create(clientsEmail);
                return Ok(clientsEmail);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClientsEmail>> Put(ClientsEmail clientsEmail)
        {
            if (clientsEmail == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsEmailsRepository.Update(clientsEmail);
                return Ok(clientsEmail);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientsEmail>> Delete(long id)
        {
            ClientsEmail clientsEmail = await clientsEmailsRepository.Get(id);
            if (clientsEmailsRepository == null)
            {
                return NotFound();
            }
            else
            {
                await clientsEmailsRepository.Delete(clientsEmail);
                return Ok(clientsEmail);
            }
        }
    }
}
