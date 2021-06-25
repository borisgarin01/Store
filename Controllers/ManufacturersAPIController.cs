using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ManufacturersAPIController : ControllerBase
    {
        private IManufacturersRepository manufacturersRepository;

        public ManufacturersAPIController(IManufacturersRepository manufacturersRepo)
        {
            manufacturersRepository = manufacturersRepo;
        }
    }
}
