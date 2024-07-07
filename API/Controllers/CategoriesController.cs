using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Interfaces.Derived;

namespace API.Controllers;

[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesRepository _categoriesRepository;
    public CategoriesController(ICategoriesRepository categoriesRepository)
    {
        _categoriesRepository = categoriesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Product>> Index()
    {
        return Ok(await _categoriesRepository.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> AddCategoryAsync(Category category)
    {
        await _categoriesRepository.AddAsync(category);
        return Created("api/Categories", category);
    }
}
