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
    [Route("api/ClientsPhonesNumbers")]
    public class ClientsPhonesNumbersAPIController : ControllerBase
    {
        private IClientsPhonesNumbersRepository clientsPhonesNumbersRepository;

        public ClientsPhonesNumbersAPIController(IClientsPhonesNumbersRepository clientsPhonesNumbersRepo)
        {
            clientsPhonesNumbersRepository = clientsPhonesNumbersRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientsPhonesNumber>> Get()
        {
            return await clientsPhonesNumbersRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientsPhonesNumber>> Get(int id)
        {
            return new ObjectResult(await clientsPhonesNumbersRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<ClientsPhonesNumber>> Post(ClientsPhonesNumber clientsPhonesNumber)
        {
            if (clientsPhonesNumber == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsPhonesNumbersRepository.Create(clientsPhonesNumber);
                return Ok(clientsPhonesNumber);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClientsPhonesNumber>> Put(ClientsPhonesNumber clientsPhonesNumber)
        {
            if (clientsPhonesNumber == null)
            {
                return BadRequest();
            }
            else
            {
                await clientsPhonesNumbersRepository.Update(clientsPhonesNumber);
                return Ok(clientsPhonesNumber);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientsPhonesNumber>> Delete(long id)
        {
            ClientsPhonesNumber clientsPhonesNumber = await clientsPhonesNumbersRepository.Get(id);
            if (clientsPhonesNumber == null)
            {
                return NotFound();
            }
            else
            {
                await clientsPhonesNumbersRepository.Delete(clientsPhonesNumber);
                return Ok(clientsPhonesNumber);
            }
        }
    }
}
