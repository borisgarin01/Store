using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;

namespace Store.Controllers
{
    [ApiController]
    public class CategoriesAPIController : ControllerBase
    {
        private StoreContext storeContext;

        public CategoriesAPIController(StoreContext context)
        {
            storeContext = context;
        }
    }
}
