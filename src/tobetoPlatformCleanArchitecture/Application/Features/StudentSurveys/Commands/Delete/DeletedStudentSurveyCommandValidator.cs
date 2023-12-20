using FluentValidation;

namespace Application.Features.StudentSurveys.Commands.Delete;

public class DeleteStudentSurveyCommandValidator : AbstractValidator<DeleteStudentSurveyCommand>
{
    public DeleteStudentSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}