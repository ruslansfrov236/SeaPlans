using seaplan.business.ViewsModels.About;

namespace seaplan.business.Validators.AbstractValidator;

public class UpdateAboutValidator : AbstractValidator<UpdateAboutVM>
{
    public UpdateAboutValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

        RuleFor(x => x.FormFile)
            .NotEmpty().WithMessage("File cannot be empty.")
            .Must(file => file.Length > 0).WithMessage("File cannot be empty.")
            .Must(file => allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("Only .jpg, .jpeg, .png, .gif formats are allowed.")
            .Must(file => file.Length <= 5 * 1024 * 1024).WithMessage("File size must be less than 5MB.");
    }
}