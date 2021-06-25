using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class OrdersItemsAPIController : ControllerBase
    {
        private IOrdersItemsRepository ordersItemsRepository;

        public OrdersItemsAPIController(IOrdersItemsRepository ordersItemsRepo)
        {
            ordersItemsRepository = ordersItemsRepo;
        }
    }
}
