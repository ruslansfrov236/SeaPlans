using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.Concrete;
using seaplan.business.ViewsModels.Auth;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]CreateLoginVM model)
    {
        var login = await _authService.Login(model);
        return Ok(login);
    }

    [HttpPost("registration")]
    public async Task<IActionResult> Registration([FromBody]CreateRegistrationVM model)
    {
        var login = await _authService.CreateUser(model);
        return Ok(login);
    }

    [HttpGet("{userOrEmail}")]
    public async Task<IActionResult> EmailFilter(string userOrEmail)
    {
        var filter = await _authService.EmailFilter(userOrEmail);
        return Ok(filter);
    }

    [HttpGet("verification-smtp/{userId}")]
    public async Task<IActionResult> VerificationSmtp(string userId)
    {
        var user = await _authService.VerificationSmtp(userId);

        return Ok(user);
    }
}