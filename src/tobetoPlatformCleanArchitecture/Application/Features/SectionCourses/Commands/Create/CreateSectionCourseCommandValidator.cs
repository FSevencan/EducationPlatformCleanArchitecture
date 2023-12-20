using FluentValidation;

namespace Application.Features.SectionCourses.Commands.Create;

public class CreateSectionCourseCommandValidator : AbstractValidator<CreateSectionCourseCommand>
{
    public CreateSectionCourseCommandValidator()
    {
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.Section).NotEmpty();
        RuleFor(c => c.Course).NotEmpty();
    }
}