using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    public Product[] Products { get; init; }
    public ProductsController()
    {
        Products =
        [
            new Product { Name = "Intel Xeon E2620 v3", CreatedAt=DateTime.UtcNow, Description="Xeon E2620 v3"  },
            new Product { Name = "Xeon E2670 v3", CreatedAt=DateTime.UtcNow, Description="Xeon E2670 v3"}
        ];
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(Products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductAsync(Product product)
    {
        return Created("api/Products", product);
    }
}