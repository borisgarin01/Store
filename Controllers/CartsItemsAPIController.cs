using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class CartsItemsAPIController : ControllerBase
    {
        private ICartsItemsRepository cartsItemsRepository;

        public CartsItemsAPIController(ICartsItemsRepository cartsItemsRepo)
        {
            cartsItemsRepository = cartsItemsRepo;
        }
    }
}
