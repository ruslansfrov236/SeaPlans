using task.Webui.ViewsModels.Auth;

namespace seaplan.business.Validators.AbstractValidator;

public class UpdateRolesValidator : AbstractValidator<UpdateRolesVM>
{
    public UpdateRolesValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
        RuleFor(a => a.RoleModel)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
    }
}