using FluentValidation;

namespace Application.Features.Surveys.Commands.Update;

public class UpdateSurveyCommandValidator : AbstractValidator<UpdateSurveyCommand>
{
    public UpdateSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.FinishDate).NotEmpty();
    }
}