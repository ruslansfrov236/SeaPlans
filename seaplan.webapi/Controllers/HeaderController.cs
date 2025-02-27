using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Header;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeaderController : ControllerBase
{
    private readonly IHeaderService _headerService;

    public HeaderController(IHeaderService headerService)
    {
        _headerService = headerService;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var header = await _headerService.GetAll();

        return Ok(header);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        return await _headerService.GetById(id).ContinueWith(a => Ok(a.Result));
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateHeaderVM model)
    {
        return await _headerService.Create(model).ContinueWith(a => StatusCode((int)HttpStatusCode.Created, a.Result));
    }


    [HttpPut]
    public async Task<IActionResult> Update(UpdateHeaderVM model)
    {
        return await _headerService.Update(model).ContinueWith(a => Ok(a.Result));
    }


    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        return await _headerService.Delete(id).ContinueWith(a => Ok(a.Result));
    }
}