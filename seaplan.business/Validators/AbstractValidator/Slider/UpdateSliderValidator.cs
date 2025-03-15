using task.Webui.ViewsModels.Slider;

namespace seaplan.business.Validators.AbstractValidator;

public class UpdateSliderValidator : AbstractValidator<UpdateSliderVM>
{
    public UpdateSliderValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.");

        RuleFor(a => a.Descriptions)
            .NotEmpty()
            .WithMessage("Please do not enter blank information.")
            .MinimumLength(2).WithMessage("Description must be at least 2 characters long.")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters long.");

        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

        RuleFor(x => x.FormFile)
            .NotNull().WithMessage("File is required.")
            .NotEmpty().WithMessage("File cannot be empty.")
            .Must(file => file.Length > 0).WithMessage("File cannot be empty.")
            .Must(file => allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            .WithMessage("Only .jpg, .jpeg, .png, .gif formats are allowed.")
            .Must(file => file.Length <= 5 * 1024 * 1024).WithMessage("File size must be less than 5MB.");
    }
}