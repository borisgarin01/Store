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
    public class LeftoversInStoresAPIController : ControllerBase
    {
        private ILeftoversInStoresRepository leftoversInStoresRepository;

        public LeftoversInStoresAPIController(ILeftoversInStoresRepository leftoversInStoresRepo)
        {
            leftoversInStoresRepository = leftoversInStoresRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await leftoversInStoresRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            LeftoversInStore leftoversInStore = await leftoversInStoresRepository.Get(id);
            if (leftoversInStore != null)
            {
                return Ok(leftoversInStore);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            LeftoversInStore leftoversInStore = await leftoversInStoresRepository.Get(id);
            if (leftoversInStore != null)
            {
                await leftoversInStoresRepository.Update(leftoversInStore);
            }
            return Ok(leftoversInStoresRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(LeftoversInStore leftoversInStore)
        {
            await leftoversInStoresRepository.Create(leftoversInStore);
            return Ok(leftoversInStoresRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            LeftoversInStore leftoversInStore = await leftoversInStoresRepository.Get(id);
            if (leftoversInStore != null)
            {
                await leftoversInStoresRepository.Delete(leftoversInStore);
            }
            return Ok(leftoversInStoresRepository.GetAll());
        }
    }
}