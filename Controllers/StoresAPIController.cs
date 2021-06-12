using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Repositories.Interfaces;

#nullable disable

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresAPIController : ControllerBase
    {
        private IStoresRepository storesRepository;

        public StoresAPIController(IStoresRepository storesRepo)
        {
            storesRepository = storesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await storesRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            Models.Store store = await storesRepository.Get(id);
            if (store != null)
            {
                return Ok(store);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            Models.Store store = await storesRepository.Get(id);
            if (store != null)
            {
                await storesRepository.Update(store);
            }
            return Ok(storesRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Store store)
        {
            await storesRepository.Create(store);
            return Ok(storesRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            Models.Store store = await storesRepository.Get(id);
            if (store != null)
            {
                await storesRepository.Delete(store);
            }
            return Ok(storesRepository.GetAll());
        }
    }
}
