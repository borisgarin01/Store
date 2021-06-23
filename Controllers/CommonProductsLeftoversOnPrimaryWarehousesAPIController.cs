using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class CommonProductsLeftoversOnPrimaryWarehousesAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public CommonProductsLeftoversOnPrimaryWarehousesAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
