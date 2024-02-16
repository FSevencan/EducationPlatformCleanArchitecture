using FluentValidation;

namespace Application.Features.StudentLessons.Commands.Delete;

public class DeleteStudentLessonCommandValidator : AbstractValidator<DeleteStudentLessonCommand>
{
    public DeleteStudentLessonCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}