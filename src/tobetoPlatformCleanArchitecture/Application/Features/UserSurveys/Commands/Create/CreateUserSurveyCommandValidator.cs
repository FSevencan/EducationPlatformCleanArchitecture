using FluentValidation;

namespace Application.Features.UserSurveys.Commands.Create;

public class CreateUserSurveyCommandValidator : AbstractValidator<CreateUserSurveyCommand>
{
    public CreateUserSurveyCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}