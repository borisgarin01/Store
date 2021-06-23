using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ClientsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
