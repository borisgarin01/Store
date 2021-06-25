using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        private IProductsRepository productsRepository;

        public ProductsAPIController(IProductsRepository productsRepo)
        {
            productsRepository = productsRepo;
        }
    }
}
