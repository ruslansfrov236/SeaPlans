using seaplan.entity.Entities.Identity;


namespace seaplan.business.Abstract;

public interface IUserService
{
    Task<bool>  UpdateRefreshToken (string refreshToken, AppUser user, DateTime refreshTokenDate ,int addOnAccessTokenDate);
    Task UpdatedPassword(string userId , string resetToken , string newPassword);
    Task<List<AppUser>> GetAllUsersAsync(int page, int size);
   
    int TotalUsersCount {get;}
    Task AssignRoleToUserAsync( string userId , string[] Roles);
    Task<string[]> GetRoleToUserAsync( string userIdOrName);
    Task<bool> AssignRoleDeleteUser(string userId);
}