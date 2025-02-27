using Microsoft.AspNetCore.Identity;
using seaplan.entity.Entities.Identity;

namespace seaplan.business.Concrete;

public class UserService : IUserService
{
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IVerificationCodeService _verificationCodeService;

    public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,
        IVerificationCodeService verificationCodeService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _verificationCodeService = verificationCodeService;
    }

    public async Task<bool> UpdateRefreshToken(string refreshToken, AppUser user, DateTime refreshTokenDate,
        int addOnAccessTokenDate)
    {
        if (user == null) throw new NotFoundException("User not found");

        user.RefreshToken = refreshToken;
        user.RefreshTokenEndDate = refreshTokenDate.ToUniversalTime().AddSeconds(addOnAccessTokenDate);

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }


    public async Task UpdatedPassword(string userId, string resetToken, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);

            if (result.Succeeded) await _userManager.UpdateSecurityStampAsync(user);
        }
    }

    public async Task<List<AppUser>> GetAllUsersAsync(int page, int size)
    {
        var user = await _userManager.Users.Skip(page * size).Take(size).ToListAsync();

        return user;
    }

    public int TotalUsersCount => _userManager.Users.Count();

    public async Task AssignRoleToUserAsync(string userId, string[] Roles)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);
            await _userManager.AddToRolesAsync(user, Roles);
        }
    }


    public async Task<string[]> GetRoleToUserAsync(string userIdOrName)
    {
        var user = await _userManager.FindByIdAsync(userIdOrName)
                   ?? await _userManager.FindByNameAsync(userIdOrName);

        if (user == null)
            throw new NotFoundException("User not found");

        return (await _userManager.GetRolesAsync(user)).ToArray();
    }


    public async Task<bool> AssignRoleDeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);


            foreach (var roleName in userRoles) await _userManager.RemoveFromRoleAsync(user, roleName);

            return true;
        }

        return false;
    }
}