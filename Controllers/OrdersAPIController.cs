using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class OrdersAPIController : ControllerBase
    {
        private IOrdersRepository ordersRepository;

        public OrdersAPIController(IOrdersRepository ordersRepo)
        {
            ordersRepository = ordersRepo;
        }
    }
}
