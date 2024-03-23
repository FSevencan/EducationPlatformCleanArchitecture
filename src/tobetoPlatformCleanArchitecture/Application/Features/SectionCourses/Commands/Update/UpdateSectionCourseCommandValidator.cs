using FluentValidation;

namespace Application.Features.SectionCourses.Commands.Update;

public class UpdateSectionCourseCommandValidator : AbstractValidator<UpdateSectionCourseCommand>
{
    public UpdateSectionCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
       
    }
}