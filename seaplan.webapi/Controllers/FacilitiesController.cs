using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Facilities;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacilitiesController : ControllerBase
{
    private readonly IFacilitiesService _facilitiesService;

    public FacilitiesController(IFacilitiesService facilitiesService)
    {
        _facilitiesService = facilitiesService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var slider = await _facilitiesService.GetAll();
        return Ok(slider);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var slider = await _facilitiesService.GetById(id);
        return Ok(slider);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateFacilitiesVM model)
    {
        await _facilitiesService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateFacilitiesVM model)
    {
        await _facilitiesService.Update(model);
        return StatusCode((int)HttpStatusCode.OK);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _facilitiesService.Delete(id);
        return StatusCode((int)HttpStatusCode.OK);
    }
}