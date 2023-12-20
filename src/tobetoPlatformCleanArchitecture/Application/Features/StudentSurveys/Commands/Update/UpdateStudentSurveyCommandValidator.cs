using FluentValidation;

namespace Application.Features.StudentSurveys.Commands.Update;

public class UpdateStudentSurveyCommandValidator : AbstractValidator<UpdateStudentSurveyCommand>
{
    public UpdateStudentSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
        RuleFor(c => c.Student).NotEmpty();
        RuleFor(c => c.Survey).NotEmpty();
    }
}