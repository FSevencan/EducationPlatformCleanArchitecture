using FluentValidation;

namespace Application.Features.UserAnswers.Commands.Create;

public class CreateUserAnswerCommandValidator : AbstractValidator<CreateUserAnswerCommand>
{
    public CreateUserAnswerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ChoiceId).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.AnswerText).NotEmpty();
       
    }
}