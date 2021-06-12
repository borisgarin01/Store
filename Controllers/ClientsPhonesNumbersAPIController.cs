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
    public class ClientsPhonesNumbersAPIController : ControllerBase
    {
        private IClientsPhonesNumbersRepository clientsPhonesNumbersRepository;

        public ClientsPhonesNumbersAPIController(IClientsPhonesNumbersRepository clientsPhonesNumbersRepo)
        {
            clientsPhonesNumbersRepository = clientsPhonesNumbersRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await clientsPhonesNumbersRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            ClientPhoneNumber clientPhoneNumber = await clientsPhonesNumbersRepository.Get(id);
            if (clientPhoneNumber != null)
            {
                return Ok(clientPhoneNumber);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            ClientPhoneNumber clientPhoneNumber = await clientsPhonesNumbersRepository.Get(id);
            if (clientPhoneNumber != null)
            {
                await clientsPhonesNumbersRepository.Update(clientPhoneNumber);
            }
            return Ok(clientsPhonesNumbersRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientPhoneNumber clientPhoneNumber)
        {
            await clientsPhonesNumbersRepository.Create(clientPhoneNumber);
            return Ok(clientsPhonesNumbersRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            ClientPhoneNumber clientPhoneNumber = await clientsPhonesNumbersRepository.Get(id);
            if (clientPhoneNumber != null)
            {
                await clientsPhonesNumbersRepository.Delete(clientPhoneNumber);
            }
            return Ok(clientsPhonesNumbersRepository.GetAll());
        }
    }
}