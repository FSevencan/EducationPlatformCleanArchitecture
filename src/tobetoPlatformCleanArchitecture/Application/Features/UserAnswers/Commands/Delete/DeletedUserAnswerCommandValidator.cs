using FluentValidation;

namespace Application.Features.UserAnswers.Commands.Delete;

public class DeleteUserAnswerCommandValidator : AbstractValidator<DeleteUserAnswerCommand>
{
    public DeleteUserAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}