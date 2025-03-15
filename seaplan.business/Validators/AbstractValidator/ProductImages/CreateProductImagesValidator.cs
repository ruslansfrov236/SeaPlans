namespace seaplan.business.Validators.AbstractValidator;

public class CreateProductImagesValidator : AbstractValidator<CreateProductImagesVM>
{
    public CreateProductImagesValidator()
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };

        RuleFor(x => x.FormFile)
            .NotNull().WithMessage("At least one file is required.")
            .Must(files => files != null && files.Count > 0).WithMessage("At least one file must be uploaded.")
            .Must(files => files.All(file => file.Length > 0)).WithMessage("Files cannot be empty.")
            .Must(files => files.All(file => file.Length <= 5 * 1024 * 1024))
            .WithMessage("Each file size must be less than 5MB.")
            .Must(files => files.All(file =>
                allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower())))
            .WithMessage("Only .jpg, .jpeg, .png, .gif formats are allowed.");
    }
}