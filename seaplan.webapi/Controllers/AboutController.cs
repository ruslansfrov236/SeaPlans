using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.About;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _aboutService;

    public AboutController(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var about = await _aboutService.GetAll();

        return Ok(about);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index([FromRoute] string id)
    {
        var about = await _aboutService.GetById(id);
        return Ok(about);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] CreateAboutVM model)
    {
        await _aboutService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }


    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromForm] UpdateAboutVM model)
    {
        await _aboutService.Update(model);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _aboutService.Delete(id);
        return Ok();
    }
}