using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsAddressesAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ClientsAddressesAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
