namespace task.Webui.ViewModels.Auth;

public record VerificationCode
{
    public string UserId { get; init; }
    public string Code { get; init; }
    public DateTime ExpiryTime { get; init; }

    public VerificationCode(string userId, string code, DateTime expiryTime)
    {
        UserId = userId;
        Code = code;
        ExpiryTime = expiryTime;
    }
}