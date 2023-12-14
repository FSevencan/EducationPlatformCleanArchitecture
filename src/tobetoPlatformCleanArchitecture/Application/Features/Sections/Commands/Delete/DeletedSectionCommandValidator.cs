using FluentValidation;

namespace Application.Features.Sections.Commands.Delete;

public class DeleteSectionCommandValidator : AbstractValidator<DeleteSectionCommand>
{
    public DeleteSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}