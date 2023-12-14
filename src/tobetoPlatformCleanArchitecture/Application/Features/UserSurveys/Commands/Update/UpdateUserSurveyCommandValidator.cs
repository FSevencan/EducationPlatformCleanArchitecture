using FluentValidation;

namespace Application.Features.UserSurveys.Commands.Update;

public class UpdateUserSurveyCommandValidator : AbstractValidator<UpdateUserSurveyCommand>
{
    public UpdateUserSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
    }
}