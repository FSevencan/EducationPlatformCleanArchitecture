using FluentValidation;

namespace Application.Features.StudentSections.Commands.Update;

public class UpdateStudentSectionCommandValidator : AbstractValidator<UpdateStudentSectionCommand>
{
    public UpdateStudentSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
      
    }
}