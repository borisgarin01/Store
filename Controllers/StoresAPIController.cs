using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/Stores")]
    public class StoresAPIController : ControllerBase
    {
        private IStoresRepository storesRepository;

        public StoresAPIController(IStoresRepository storesRepo)
        {
            storesRepository = storesRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Store>> Get()
        {
            return await storesRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Store>> Get(int id)
        {
            return new ObjectResult(await storesRepository.Get(id));
        }







        [HttpPost]
        public async Task<ActionResult<Models.Store>> Post(Models.Store store)
        {
            if (store == null)
            {
                return BadRequest();
            }
            else
            {
                await storesRepository.Create(store);
                return Ok(store);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Models.Store>> Put(Models.Store store)
        {
            if (store == null)
            {
                return BadRequest();
            }
            else
            {
                await storesRepository.Update(store);
                return Ok(store);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Store>> Delete(long id)
        {
            Models.Store store = await storesRepository.Get(id);
            if (store == null)
            {
                return NotFound();
            }
            else
            {
                await storesRepository.Delete(store);
                return Ok(store);
            }
        }
    }
}
