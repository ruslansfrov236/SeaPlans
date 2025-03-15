
namespace seaplan.business.Concrete;

public class AuthService : IAuthService
{
    private readonly IEmailService _emailService;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenHandler _tokenHandler;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;
    private readonly IVerificationCodeService _verificationCodeService;

    public AuthService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
        SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService,
        IEmailService emailService, IVerificationCodeService verificationCodeService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _tokenHandler = tokenHandler;
        _userService = userService;
        _emailService = emailService;
        _verificationCodeService = verificationCodeService;
    }

    public async Task<AppUser> CreateUser(CreateRegistrationVM model)
    {
        var existingUser = await _userManager.FindByEmailAsync(model.Email);
        if (existingUser != null) throw new BadRequestException("Email already exists.");


        var isboolReplayUserName = await _userManager.FindByNameAsync(model.FullName);
        if (isboolReplayUserName != null) throw new BadRequestException("Values is replay username");


        var user = new AppUser
        {
            Id = Guid.NewGuid().ToString(),

            UserName = model.FullName,
            FirstName = model.FirstName,
            LastName = model.LastName,

            Email = model.Email
        };


        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            foreach (var error in result.Errors)
                throw new BadRequestException(error.Description);


        if (!string.IsNullOrWhiteSpace(user.Email))
        {
            var code = _verificationCodeService.GenerateVerificationCode();


            await _verificationCodeService.SaveVerificationCodeAsync(user.Id, code);
            await _emailService.SendVerificationCodeEmailAsync(user.Email, code, user.UserName);
            await _userManager.AddToRoleAsync(user, nameof(RoleModel.User));
        }

        return user;
    }

    public async Task<Token> Login(CreateLoginVM model)
    {
        var user = await _userManager.FindByNameAsync(model.usernameOrEmail) ??
                   await _userManager.FindByEmailAsync(model.usernameOrEmail) ??
                   throw new NotFoundException("User or email not found.");


        var emailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        if (!emailConfirmed) throw new BadRequestException("Email not verified");


        var result = await _signInManager.PasswordSignInAsync(user, model.password, true, false);
        if (result.Succeeded)
        {
            var token = await _tokenHandler.CreateAccessToken(model.accessTokenLifeTime, user);
            var refreshToken =  _tokenHandler.DecryptRefreshToken(user.RefreshToken);
            await _userService.UpdateRefreshToken(refreshToken, user, token.Expiration, 900);
           
            return token;
        }

        throw new PasswordChangeFailedException("Invalid username, email address, or password");
    }

    public async Task<bool> EmailFilter(string userORname)
    {
        var em = await _userManager.FindByEmailAsync(userORname)
                 ?? await _userManager.FindByNameAsync(userORname);


        if (em != null)
        {
            var refreshToken = await _userManager.GeneratePasswordResetTokenAsync(em);
            await _emailService.SendPasswordResetMailAsync(em.Email, em.Id, refreshToken);
        }

        return true;
    }


    public async Task<bool> VerificationSmtp(string userId)
    {
        if (!Guid.TryParse(userId, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var code = _verificationCodeService.GenerateVerificationCode();
        var user = await _userManager.FindByIdAsync(guid.ToString());
        if (user != null) await _emailService.SendVerificationCodeEmailAsync(user.Email, code, user.UserName);

        return true;
    }
}