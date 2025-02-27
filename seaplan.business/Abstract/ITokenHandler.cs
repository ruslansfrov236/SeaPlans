using seaplan.entity.Entities.Identity;

namespace seaplan.business.Abstract;

public interface ITokenHandler
{
    Task<Token> CreateAccessToken(int second, AppUser appUser);
    string DecryptRefreshToken(string encryptedToken);
   
}