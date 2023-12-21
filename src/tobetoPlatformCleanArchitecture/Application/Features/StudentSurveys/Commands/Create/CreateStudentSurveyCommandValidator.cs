using FluentValidation;

namespace Application.Features.StudentSurveys.Commands.Create;

public class CreateStudentSurveyCommandValidator : AbstractValidator<CreateStudentSurveyCommand>
{
    public CreateStudentSurveyCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SurveyId).NotEmpty();
       
    }
}