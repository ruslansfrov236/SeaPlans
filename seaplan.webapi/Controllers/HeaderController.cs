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
        var header = await _headerService.GetById(id);
        return Ok(header);
    }


    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] CreateHeaderVM model)
    {
        await _headerService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }


    [HttpPut("update")]
    public async Task<IActionResult> Update([FromForm] UpdateHeaderVM model)
    {
        var header = await _headerService.Update(model);

        return Ok(header);
    }


    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _headerService.Delete(id);
        return Ok();
    }
}