using FluentValidation;

namespace Application.Features.UserAnswers.Commands.Update;

public class UpdateUserAnswerCommandValidator : AbstractValidator<UpdateUserAnswerCommand>
{
    public UpdateUserAnswerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.ChoiceId).NotEmpty();
        RuleFor(c => c.QuestionId).NotEmpty();
        RuleFor(c => c.AnswerText).NotEmpty();
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.Choice).NotEmpty();
    }
}