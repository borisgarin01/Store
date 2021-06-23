using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class OrdersItemsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public OrdersItemsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
