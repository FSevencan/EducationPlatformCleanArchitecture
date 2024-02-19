using FluentValidation;

namespace Application.Features.Choices.Commands.Delete;

public class DeleteChoiceCommandValidator : AbstractValidator<DeleteChoiceCommand>
{
    public DeleteChoiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}