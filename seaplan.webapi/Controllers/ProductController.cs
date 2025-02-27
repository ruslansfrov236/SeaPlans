using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Products;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
     var product =   await _productService.GetAll();

     return Ok(product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
    var product =    await _productService.GetById(id);
    return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductVM model)
    {
        await _productService.Create(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductVM model)
    {
        await _productService.Update(model);
        return Ok();
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _productService.Delete(id);
        return Ok();
    }
}