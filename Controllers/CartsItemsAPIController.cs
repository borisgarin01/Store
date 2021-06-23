using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class CartsItemsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public CartsItemsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
