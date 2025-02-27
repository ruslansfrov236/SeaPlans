namespace seaplan.business.ViewsModel.Auth;

public class CreateVerifaction
{
    public string UserId { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime ExpiryTime { get; set; } = DateTime.UtcNow.AddMinutes(60);
}