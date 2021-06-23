using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsPhonesNumbersAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ClientsPhonesNumbersAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
