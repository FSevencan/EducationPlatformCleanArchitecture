using FluentValidation;

namespace Application.Features.SectionInstructors.Commands.Update;

public class UpdateSectionInstructorCommandValidator : AbstractValidator<UpdateSectionInstructorCommand>
{
    public UpdateSectionInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.Section).NotEmpty();
        RuleFor(c => c.Instructor).NotEmpty();
    }
}