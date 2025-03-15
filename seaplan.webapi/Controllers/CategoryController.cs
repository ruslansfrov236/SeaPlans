using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Category;

namespace seaplan.webapi;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var category = await _categoryService.GetAll();
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var category = await _categoryService.GetById(id);
        return Ok(category);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryVM model)
    {
        await _categoryService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryVM model)
    {
        await _categoryService.Update(model);
        return Ok();
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _categoryService.Delete(id);
        return Ok();
    }
}