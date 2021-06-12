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
    public class ClientsEmailsAPIController : ControllerBase
    {
        private IClientsEmailsRepository clientsEmailsRepository;

        public ClientsEmailsAPIController(IClientsEmailsRepository clientsEmailsRepo)
        {
            clientsEmailsRepository = clientsEmailsRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await clientsEmailsRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            ClientEmail clientEmail = await clientsEmailsRepository.Get(id);
            if (clientEmail != null)
            {
                return Ok(clientEmail);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            ClientEmail clientEmail = await clientsEmailsRepository.Get(id);
            if (clientEmail != null)
            {
                await clientsEmailsRepository.Update(clientEmail);
            }
            return Ok(clientsEmailsRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientEmail clientEmail)
        {
            await clientsEmailsRepository.Create(clientEmail);
            return Ok(clientsEmailsRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            ClientEmail clientEmail = await clientsEmailsRepository.Get(id);
            if (clientEmail != null)
            {
                await clientsEmailsRepository.Delete(clientEmail);
            }
            return Ok(clientsEmailsRepository.GetAll());
        }
    }
}