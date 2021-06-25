using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class StoresAPIController : ControllerBase
    {
        private IStoresRepository storesRepository;

        public StoresAPIController(IStoresRepository storesRepo)
        {
            storesRepository = storesRepo;
        }
    }
}
