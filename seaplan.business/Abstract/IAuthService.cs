using seaplan.business.ViewsModels.Auth;
using seaplan.entity.Entities.Identity;

namespace seaplan.business.Abstract;

public interface IAuthService
{
    Task<AppUser> CreateUser(CreateRegistrationVM model);
    Task<Token> Login(CreateLoginVM model);
    Task<bool> EmailFilter(string userORname);
    Task<bool> VerificationSmtp(string userId);
}