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
    public class CommonProductsLeftoversOnPrimaryWarehouseAPIController : ControllerBase
    {
        private ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepository;

        public CommonProductsLeftoversOnPrimaryWarehouseAPIController(ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepo)
        {
            commonProductsLeftoversOnPrimaryWarehouseRepository = commonProductsLeftoversOnPrimaryWarehouseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll());
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse = await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id);
            if (commonProductLeftoversOnPrimaryWarehouse != null)
            {
                return Ok(commonProductLeftoversOnPrimaryWarehouse);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(long id)
        {
            CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse = await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id);
            if (commonProductLeftoversOnPrimaryWarehouse != null)
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Update(commonProductLeftoversOnPrimaryWarehouse);
            }
            return Ok(commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse)
        {
            await commonProductsLeftoversOnPrimaryWarehouseRepository.Create(commonProductLeftoversOnPrimaryWarehouse);
            return Ok(commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            CommonProductLeftoversOnPrimaryWarehouse commonProductLeftoversOnPrimaryWarehouse = await commonProductsLeftoversOnPrimaryWarehouseRepository.Get(id);
            if (commonProductLeftoversOnPrimaryWarehouse != null)
            {
                await commonProductsLeftoversOnPrimaryWarehouseRepository.Delete(commonProductLeftoversOnPrimaryWarehouse);
            }
            return Ok(commonProductsLeftoversOnPrimaryWarehouseRepository.GetAll());
        }
    }
}