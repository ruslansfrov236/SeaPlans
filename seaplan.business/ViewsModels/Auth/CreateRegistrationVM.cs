using System.ComponentModel.DataAnnotations;

namespace seaplan.business.ViewsModels.Auth;

public class CreateRegistrationVM
{
    public string FullName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }

    public string? Password { get; set; }


    public string? ConfirmPassword { get; set; }
}