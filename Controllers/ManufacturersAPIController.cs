using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ManufacturersAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ManufacturersAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
