using FluentValidation;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
             .NotEmpty().WithMessage("Category name is required.")
             .MinimumLength(3).WithMessage("Category name must be at least 3 characters long.")
             .MaximumLength(30).WithMessage("Category name must be less than 30 characters.")
             .Matches("^[^0-9]*$").WithMessage("Category name cannot contain numbers.");

        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}