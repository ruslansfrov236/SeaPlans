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
        return await _aboutService.GetAll().ContinueWith(a => Ok(a.Result));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
        => await _aboutService.GetById(id).ContinueWith(a => Ok(a.Result));


    [HttpPost]
    public async Task<IActionResult> Create(CreateAboutVM model)
    => await _aboutService.Create(model).ContinueWith(a => StatusCode((int)HttpStatusCode.Created, a.Result));
    

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAboutVM model)
    => await _aboutService.Update(model).ContinueWith(a => Ok(a.Result));
    

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    => await _aboutService.Delete(id).ContinueWith(a => Ok(a.Result));
    
}