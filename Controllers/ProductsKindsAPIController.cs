using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class ProductsKindsAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public ProductsKindsAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
