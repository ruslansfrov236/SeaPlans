namespace seaplan.business.Validators.AbstractValidator;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryVM>
{
    public UpdateCategoryValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
    }
}