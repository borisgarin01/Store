using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class LeftoversInStoresAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public LeftoversInStoresAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
