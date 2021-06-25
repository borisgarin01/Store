using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class CartsAPIController : ControllerBase
    {
        private ICartsRepository cartsRepository;

        public CartsAPIController(ICartsRepository cartsRepo)
        {
            cartsRepository = cartsRepo;
        }
    }
}
