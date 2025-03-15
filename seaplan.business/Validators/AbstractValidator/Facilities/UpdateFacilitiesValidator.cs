namespace seaplan.business.Validators.AbstractValidator;

public class UpdateFacilitiesValidator : AbstractValidator<UpdateFacilitiesVM>
{
    public UpdateFacilitiesValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
        RuleFor(a => a.Icon)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");
    }
}