using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class StoresAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public StoresAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
