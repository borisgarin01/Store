using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ProductsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
