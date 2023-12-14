using FluentValidation;

namespace Application.Features.Surveys.Commands.Create;

public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
{
    public CreateSurveyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.FinishDate).NotEmpty();
    }
}