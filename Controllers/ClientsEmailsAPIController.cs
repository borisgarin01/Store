using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ClientsEmailsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ClientsEmailsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
