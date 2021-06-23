using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class OrdersAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public OrdersAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
