namespace seaplan.business.Validators;

public class CreateMessagesValidator : AbstractValidator<CreateMessagesVM>
{
    public CreateMessagesValidator()
    {
        RuleFor(a => a.FullName)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");

        RuleFor(a => a.Email)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.")
            .EmailAddress()
            .WithMessage("Please enter a valid email address.");

        RuleFor(a => a.Comment)
            .NotEmpty()
            .WithMessage("Please provide a comment.")
            .MinimumLength(10)
            .WithMessage("Comment should be at least 10 characters long.");
    }
}