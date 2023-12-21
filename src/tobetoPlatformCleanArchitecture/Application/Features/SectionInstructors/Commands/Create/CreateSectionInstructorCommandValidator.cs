using FluentValidation;

namespace Application.Features.SectionInstructors.Commands.Create;

public class CreateSectionInstructorCommandValidator : AbstractValidator<CreateSectionInstructorCommand>
{
    public CreateSectionInstructorCommandValidator()
    {
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
      
    }
}