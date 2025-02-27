using seaplan.business.ViewsModels.Auth;

namespace seaplan.business.Validators.AbstractValidator;

public class CreateRolesValidator:AbstractValidator<CreateRolesVM>
{
    public CreateRolesValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
        RuleFor(a => a.RoleModel)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
    }
}