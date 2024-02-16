using FluentValidation;

namespace Application.Features.StudentLessons.Commands.Create;

public class CreateStudentLessonCommandValidator : AbstractValidator<CreateStudentLessonCommand>
{
    public CreateStudentLessonCommandValidator()
    {
       
        RuleFor(c => c.LessonId).NotEmpty();
       
    }
}