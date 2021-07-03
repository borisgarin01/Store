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
    [Route("api/CommonProductsLeftoversOnPrimaryWarehouses")]
    public class CommonProductsLeftoversOnPrimaryWarehousesAPIController : ControllerBase
    {
        private ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepository;

        public CommonProductsLeftoversOnPrimaryWarehousesAPIController(ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepo)
        {
            commonProductsLeftoversOnPrimaryWarehouseRepository = commonProductsLeftoversOnPrimaryWarehouseRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CommonProductsLeftoversOnPrimaryWarehouse>> Get()
        {
            return await commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommonProductsLeftoversOnPrimaryWarehouse>> Get(int id)
        {
            return new ObjectResult(await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<CommonProductsLeftoversOnPrimaryWarehouse>> Post(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            if (commonProductsLeftoversOnPrimaryWarehouse == null)
            {
                return BadRequest();
            }
            else
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Create(commonProductsLeftoversOnPrimaryWarehouse);
                return Ok(commonProductsLeftoversOnPrimaryWarehouse);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CommonProductsLeftoversOnPrimaryWarehouse>> Put(CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse)
        {
            if (commonProductsLeftoversOnPrimaryWarehouse == null)
            {
                return BadRequest();
            }
            else
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Update(commonProductsLeftoversOnPrimaryWarehouse);
                return Ok(commonProductsLeftoversOnPrimaryWarehouse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonProductsLeftoversOnPrimaryWarehouse>> Delete(long id)
        {
            CommonProductsLeftoversOnPrimaryWarehouse commonProductsLeftoversOnPrimaryWarehouse = await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id);
            if (commonProductsLeftoversOnPrimaryWarehouse == null)
            {
                return NotFound();
            }
            else
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Delete(commonProductsLeftoversOnPrimaryWarehouse);
                return Ok(commonProductsLeftoversOnPrimaryWarehouse);
            }
        }
    }
}
