using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.ProductImages;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImagesService _productImagesService;

    public ProductImagesController(IProductImagesService productImagesService)
    {
        _productImagesService = productImagesService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> UploadFile([FromForm] CreateProductImagesVM model)
    {
        var image = await _productImagesService.UploadImages(model);

        return Ok(image);
    }

    [HttpPut("update-filter")]
    public async Task<IActionResult> UpdateFilter(string id, string productId, bool isActivated)
    {
        var image = await _productImagesService.ImageActivated(id, productId, isActivated);

        return Ok(image);
    }
}