using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Interfaces.Derived;

namespace API.Controllers;

[Route("api/[controller]")]
public class ManufacturersController : ControllerBase
{
    private readonly IManufacturersRepository _manufacturersRepository;
    public ManufacturersController(IManufacturersRepository manufacturersRepository)
    {
        _manufacturersRepository = manufacturersRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Product>> Index()
    {
        return Ok(await _manufacturersRepository.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> AddManufacturerAsync(Manufacturer manufacturer)
    {
        await _manufacturersRepository.AddAsync(manufacturer);
        return Created("api/Manufacturers", manufacturer);
    }
}
