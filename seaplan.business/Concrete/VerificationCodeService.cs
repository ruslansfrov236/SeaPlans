using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using seaplan.business.Abstract;
using seaplan.business.ViewsModel.Auth;
using seaplan.entity.Entities.Identity;
using task.Webui.ViewModels.Auth;

namespace seaplan.business.Concrete;

public class VerificationCodeService : IVerificationCodeService
{
    private readonly IDistributedCache _cache;

    private readonly UserManager<AppUser> _userManager;

    public VerificationCodeService(UserManager<AppUser> userManager, IDistributedCache cache)
    {
        _userManager = userManager;
        _cache = cache;
    }

    public async Task SaveVerificationCodeAsync(string userId, string code)
    {
        var cacheKey = $"VerificationCode_{userId}";

        var verificationCode = new VerificationCode(userId, code, DateTime.UtcNow.AddMinutes(60));

        var serializedData = JsonSerializer.Serialize(verificationCode);

        var cacheEntryOptions = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(60));

        await _cache.SetStringAsync(cacheKey, serializedData, cacheEntryOptions);
    }

    public async Task VerificationCodeAsync(CreateVerifaction model)
    {
        var cacheKey = $"VerificationCode_{model.UserId}";

        var cachedData = await _cache.GetStringAsync(cacheKey);
        if (string.IsNullOrEmpty(cachedData))
            throw new Exception("The verification code is incorrect or does not exist.");

        var cachedCode = JsonSerializer.Deserialize<VerificationCode>(cachedData);
        if (cachedCode == null || cachedCode.Code != model.Code)
            throw new Exception("The verification code is incorrect.");

        if (DateTime.UtcNow > cachedCode.ExpiryTime)
        {
            await Remove(model.UserId);
            throw new Exception("The verification code has expired.");
        }

        var isConfirmed = await EmailConfiremed(cachedCode.UserId);
        if (isConfirmed) await Remove(cachedCode.UserId);
    }


    public Task Remove(string userId)
    {
        var cacheKey = $"VerificationCode_{userId}";
        _cache.Remove(cacheKey);
        return Task.CompletedTask;
    }

    public async Task<bool> EmailConfiremed(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId)
                   ?? throw new Exception("User not found");

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);


        var confirmResult = await _userManager.ConfirmEmailAsync(user, token);


        return true;
    }

    public string GenerateVerificationCode(int length = 6)
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}