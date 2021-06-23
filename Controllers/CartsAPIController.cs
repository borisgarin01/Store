using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class CartsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public CartsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
