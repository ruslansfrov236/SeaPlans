using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels.Auth;
using task.Webui.ViewsModels.Auth;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    readonly private IRolesService _rolesService;

    public RolesController(IRolesService rolesService)
    {
        _rolesService = rolesService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var roles = await _rolesService.GetAll();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Index(string id)
    {
        var roles = await _rolesService.GetById(id);
        return Ok(roles);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRolesVM model)
    {
        await _rolesService.Create(model);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRolesVM model)
    {
        var roles = await _rolesService.Update(model);
        return Ok(roles);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var roles = await _rolesService.Delete(id);
        return Ok(roles);
    }
}