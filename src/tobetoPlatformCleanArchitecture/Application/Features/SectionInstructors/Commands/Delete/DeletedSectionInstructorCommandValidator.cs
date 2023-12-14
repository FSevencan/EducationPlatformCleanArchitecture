using FluentValidation;

namespace Application.Features.SectionInstructors.Commands.Delete;

public class DeleteSectionInstructorCommandValidator : AbstractValidator<DeleteSectionInstructorCommand>
{
    public DeleteSectionInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}