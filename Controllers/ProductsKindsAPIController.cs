using System;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Repositories.Interfaces;

namespace Store.Controllers
{
    [ApiController]
    public class ProductsKindsAPIController : ControllerBase
    {
        private IProductsKindsRepository productsKindsRepository;

        public ProductsKindsAPIController(IProductsKindsRepository productsKindsRepo)
        {
            productsKindsRepository = productsKindsRepo;
        }
    }
}
