using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Slider;
using task.Webui.ViewsModels.Slider;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SliderController : ControllerBase
{
    private readonly ISliderService _sliderService;

    public SliderController(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var slider = await _sliderService.GetAll();
        return Ok(slider);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var slider = await _sliderService.GetById(id);
        return Ok(slider);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] CreateSliderVM model)
    {
        await _sliderService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromForm] UpdateSliderVM model)
    {
        await _sliderService.Update(model);
        return StatusCode((int)HttpStatusCode.OK);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _sliderService.Delete(id);
        return StatusCode((int)HttpStatusCode.OK);
    }
}