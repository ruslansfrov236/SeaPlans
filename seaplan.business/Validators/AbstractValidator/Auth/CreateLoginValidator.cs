using seaplan.business.ViewsModels.Auth;

namespace seaplan.business.Validators.AbstractValidator;

public class CreateLoginValidator : AbstractValidator<CreateLoginVM>
{
    public CreateLoginValidator()
    {
        RuleFor(a => a.usernameOrEmail)
            .NotEmpty()
            .WithMessage("Username or email cannot be empty.");

        RuleFor(a => a.password)
            .NotEmpty()
            .WithMessage("Password cannot be empty.");

        RuleFor(a => a.accessTokenLifeTime)
            .GreaterThan(0)
            .WithMessage("Access token lifetime must be greater than zero.");
    }
}