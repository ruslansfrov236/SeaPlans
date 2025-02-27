namespace seaplan.business.ViewsModels.Auth;

public class CreateLoginVM
{
    public string? password { get; set; }

    public string? usernameOrEmail { get; set; }

    public int accessTokenLifeTime { get; set; } = 900;
}