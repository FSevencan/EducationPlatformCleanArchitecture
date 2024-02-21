using FluentValidation;

namespace Application.Features.UserAnswers.Commands.Create;

public class CreateUserAnswerCommandValidator : AbstractValidator<CreateUserAnswerCommand>
{
    public CreateUserAnswerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CorrectCount).NotEmpty();
        RuleFor(c => c.WrongCount).NotEmpty();
        RuleFor(c => c.EmptyCount).NotEmpty();
        RuleFor(c => c.TotalScore).NotEmpty();

    }
}