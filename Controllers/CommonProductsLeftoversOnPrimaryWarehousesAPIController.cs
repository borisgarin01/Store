using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class CommonProductsLeftoversOnPrimaryWarehousesAPIController : ControllerBase
    {
        private ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepository;

        public CommonProductsLeftoversOnPrimaryWarehousesAPIController(ICommonProductsLeftoversOnPrimaryWarehouseRepository commonProductsLeftoversOnPrimaryWarehouseRepo)
        {
            commonProductsLeftoversOnPrimaryWarehouseRepository = commonProductsLeftoversOnPrimaryWarehouseRepo;
        }
    }
}
