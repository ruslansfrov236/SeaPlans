namespace seaplan.business.Validators.AbstractValidator;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryVM>
{
    public CreateCategoryValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
    }
}