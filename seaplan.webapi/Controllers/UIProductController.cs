using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UIProductController : ControllerBase
{
    private readonly IProductService _productService;

    public UIProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var product = await _productService.GetAll();

        return Ok(product);
    }

    [HttpGet("GroupProductCategory")]
    public async Task<IActionResult> GroupProductCategory()
    {
        var product = await _productService.GetGroupProductCategory();

        return Ok(product);
    }
}