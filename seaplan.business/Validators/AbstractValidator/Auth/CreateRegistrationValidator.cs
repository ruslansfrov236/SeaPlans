using seaplan.business.ViewsModels.Auth;

namespace seaplan.business.Validators.AbstractValidator;

public class CreateRegistrationValidator : AbstractValidator<CreateRegistrationVM>
{
    public CreateRegistrationValidator()
    {
        RuleFor(a => a.FullName)
            .NotEmpty()
            .WithMessage("Full name cannot be empty.");

        RuleFor(a => a.LastName)
            .NotEmpty()
            .WithMessage("Last name cannot be empty.");

        RuleFor(a => a.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty.");

        RuleFor(a => a.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(a => a.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty.")
            .MinimumLength(5)
            .WithMessage("Password must be at least 6 characters long.");

        RuleFor(a => a.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password cannot be empty.")
            .Equal(a => a.Password)
            .WithMessage("Confirm password must match the password.");
    }
}