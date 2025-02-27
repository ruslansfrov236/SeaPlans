using System.Net;
using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.entity.Entities.Identity;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> Index(int page = 0, int size = 5)
    {
        var user = await _userService.GetAllUsersAsync(page, size);

        return Ok(user);
    }

    [HttpGet("total-user")]
    public IActionResult TotalUser()
    {
        var user = _userService.TotalUsersCount;
        return Ok(user);
    }

    [HttpPost("AssignRoleToUserAsync")]
    public async Task<IActionResult> AssignRoleToUserAsync(string userId, string[] Roles)
    {
        await _userService.AssignRoleToUserAsync(userId, Roles);
        return Ok();
    }


    [HttpGet("GetUserRolesAsync")]
    public async Task<IActionResult> GetUserRolesAsync(string userIdOrName)
    {
        var user = await _userService.GetRoleToUserAsync(userIdOrName);

        return Ok(user);
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword(string userId, string resetToken, string newPassword)
    {
        await _userService.UpdatedPassword(userId, resetToken, newPassword);

        return StatusCode((int)HttpStatusCode.Created);
    }


    [HttpDelete("AssignRoleDeleteUser/{userIdOrName}")]
    public async Task<IActionResult> AssignRoleDeleteUser(string userIdOrName)
    {
        var user = await _userService.GetRoleToUserAsync(userIdOrName);
        return Ok();
    }

    [HttpPut("refresh-token")]
    public async Task<IActionResult> RefreshToken(string refreshToken, AppUser user, DateTime refreshTokenDate,
        int addOnAccessTokenDate)
    {
        var _user = await _userService.UpdateRefreshToken(refreshToken, user, refreshTokenDate, addOnAccessTokenDate);
        return Ok(_user);
    }
}