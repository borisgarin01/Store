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
    [Route("api/LeftoversInStores")]
    public class LeftoversInStoresAPIController : ControllerBase
    {
        private ILeftoversInStoresRepository leftoversInStoresRepository;

        public LeftoversInStoresAPIController(ILeftoversInStoresRepository leftoversInStoresRepo)
        {
            leftoversInStoresRepository = leftoversInStoresRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<LeftoversInStore>> Get()
        {
            return await leftoversInStoresRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeftoversInStore>> Get(int id)
        {
            return new ObjectResult(await leftoversInStoresRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<LeftoversInStore>> Post(LeftoversInStore leftoversInStore)
        {
            if (leftoversInStore == null)
            {
                return BadRequest();
            }
            else
            {
                await leftoversInStoresRepository.Create(leftoversInStore);
                return Ok(leftoversInStore);
            }
        }

        [HttpPut]
        public async Task<ActionResult<LeftoversInStore>> Put(LeftoversInStore leftoversInStore)
        {
            if (leftoversInStore == null)
            {
                return BadRequest();
            }
            else
            {
                await leftoversInStoresRepository.Update(leftoversInStore);
                return Ok(leftoversInStore);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeftoversInStore>> Delete(long id)
        {
            LeftoversInStore leftoversInStore = await leftoversInStoresRepository.Get(id);
            if (leftoversInStore == null)
            {
                return NotFound();
            }
            else
            {
                await leftoversInStoresRepository.Delete(leftoversInStore);
                return Ok(leftoversInStore);
            }
        }
    }
}
