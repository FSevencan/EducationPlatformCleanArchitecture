using FluentValidation;

namespace Application.Features.Languages.Commands.Delete;

public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
{
    public DeleteLanguageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}