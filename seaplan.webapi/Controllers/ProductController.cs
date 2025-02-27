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
    => await _productService.GetAll().ContinueWith(a => Ok(a.Result));
    

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    => await _productService.GetById(id).ContinueWith(a => Ok(a.Result));
    

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductVM model)
    => await _productService.Create(model).ContinueWith(a => StatusCode((int)HttpStatusCode.Created, a.Result));
    

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductVM model)
    => await _productService.Update(model).ContinueWith(a => Ok(a.Result));
    

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    => await _productService.Delete(id).ContinueWith(a => Ok(a.Result));
    
}