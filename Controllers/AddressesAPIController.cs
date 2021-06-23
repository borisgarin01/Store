using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class AddressesAPIController:ControllerBase
    {
        private StoreContext storeContext;

        public AddressesAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
