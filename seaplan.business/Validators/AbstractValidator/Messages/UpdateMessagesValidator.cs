namespace seaplan.business.Validators.AbstractValidator;

public class UpdateMessagesValidator : AbstractValidator<Messages>
{
    public UpdateMessagesValidator()
    {
        RuleFor(a => a.Comment)
            .NotEmpty()
            .WithMessage("Please provide a comment.")
            .MinimumLength(10)
            .WithMessage("Comment should be at least 10 characters long.");
    }
}