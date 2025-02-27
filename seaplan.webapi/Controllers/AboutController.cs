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
       var about =  await _aboutService.GetAll();

       return Ok(about);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var about = await _aboutService.GetById(id);
        return Ok(about);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateAboutVM model)
    {
        await _aboutService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }


    [HttpPut]
    public async Task<IActionResult> Update(UpdateAboutVM model)
    {
        await _aboutService.Update(model);
        return Ok();

    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _aboutService.Delete(id);
        return Ok();
    }

}