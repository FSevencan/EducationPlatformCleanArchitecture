using FluentValidation;

namespace Application.Features.Sections.Commands.Create;

public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
{
    public CreateSectionCommandValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
    
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}