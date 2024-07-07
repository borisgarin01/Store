using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Interfaces.Derived;

namespace API.Controllers;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsRepository _productsRepository;
    public ProductsController(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Product>> Index()
    {
        return Ok(await _productsRepository.GetAll());
    }

    [HttpPost]
    public async Task<ActionResult> AddProductAsync(Product product)
    {
        await _productsRepository.AddAsync(product);
        return Created("api/Products", product);
    }
}