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
    => await _categoryService.GetAll().ContinueWith(t => Ok(t.Result));
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    =>await _categoryService.GetById(id).ContinueWith(t => Ok(t.Result));
    

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryVM model)
    => await _categoryService.Create(model)
            .ContinueWith(t => StatusCode((int)HttpStatusCode.Created, t.Result));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryVM model)
        => await _categoryService.Update(model).ContinueWith(t => Ok(t.Result));

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id) =>
        await _categoryService.Delete(id).ContinueWith(t => Ok(t.Result));
}