using Microsoft.AspNetCore.Mvc;
using seaplan.business.Abstract;
using seaplan.business.ViewsModel.Auth;

namespace seaplan.webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VerificationCodeController : ControllerBase
{
    private readonly IVerificationCodeService _verificationCodeService;

    public VerificationCodeController(IVerificationCodeService verificationCodeService)
    {
        _verificationCodeService = verificationCodeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateVerifaction model)
    {
        var verifacation = _verificationCodeService.VerificationCodeAsync(model);

        return Ok(verifacation);
    }
}