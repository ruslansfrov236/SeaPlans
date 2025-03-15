namespace seaplan.business.Validators.AbstractValidator;

public class CreateFacilitiesValidator : AbstractValidator<CreateFacilitiesVM>
{
    public CreateFacilitiesValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
        RuleFor(a => a.Icon)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
    }
}