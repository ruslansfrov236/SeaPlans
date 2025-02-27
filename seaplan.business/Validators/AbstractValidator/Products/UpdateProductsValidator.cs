namespace seaplan.business.Validators.AbstractValidator;

public class UpdateProductsValidator : AbstractValidator<UpdateProductVM>
{
    public UpdateProductsValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Please do not enter blank information.");

        RuleFor(a => a.Description)
            .NotEmpty().WithMessage("Please do not enter blank information.")
            .MinimumLength(2).WithMessage("Description must be at least 2 characters long.")
            .MaximumLength(250).WithMessage("Description must be less than 250 characters long.");

        RuleFor(a => a.Price)
            .NotEmpty().WithMessage("Please do not enter blank information.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(a => a.CategoryId)
            .NotEmpty().WithMessage("Category is required.");
        RuleFor(a => a.selectedFeautersId)
            .NotEmpty().WithMessage("Category is required.");

        RuleFor(a => a.StockQuantity)
            .NotEmpty().WithMessage("Stock quantity is required.")
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be greater than or equal to zero.");
    }
}