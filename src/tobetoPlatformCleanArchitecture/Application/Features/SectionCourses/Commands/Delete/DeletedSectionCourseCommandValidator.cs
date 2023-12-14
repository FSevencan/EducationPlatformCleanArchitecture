using FluentValidation;

namespace Application.Features.SectionCourses.Commands.Delete;

public class DeleteSectionCourseCommandValidator : AbstractValidator<DeleteSectionCourseCommand>
{
    public DeleteSectionCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}