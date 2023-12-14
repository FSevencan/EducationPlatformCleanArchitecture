using FluentValidation;

namespace Application.Features.SectionAbouts.Commands.Delete;

public class DeleteSectionAboutCommandValidator : AbstractValidator<DeleteSectionAboutCommand>
{
    public DeleteSectionAboutCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}