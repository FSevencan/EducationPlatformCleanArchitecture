using FluentValidation;

namespace Application.Features.StudentSections.Commands.Delete;

public class DeleteStudentSectionCommandValidator : AbstractValidator<DeleteStudentSectionCommand>
{
    public DeleteStudentSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}