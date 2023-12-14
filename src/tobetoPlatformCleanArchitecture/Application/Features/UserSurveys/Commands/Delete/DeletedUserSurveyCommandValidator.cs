using FluentValidation;

namespace Application.Features.UserSurveys.Commands.Delete;

public class DeleteUserSurveyCommandValidator : AbstractValidator<DeleteUserSurveyCommand>
{
    public DeleteUserSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}