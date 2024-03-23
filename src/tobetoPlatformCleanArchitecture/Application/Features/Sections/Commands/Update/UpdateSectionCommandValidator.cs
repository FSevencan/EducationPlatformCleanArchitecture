using FluentValidation;

namespace Application.Features.Sections.Commands.Update;

public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
       
    }
}