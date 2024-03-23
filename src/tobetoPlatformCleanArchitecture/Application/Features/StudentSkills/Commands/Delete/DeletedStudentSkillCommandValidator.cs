using FluentValidation;

namespace Application.Features.StudentSkills.Commands.Delete;

public class DeleteStudentSkillCommandValidator : AbstractValidator<DeleteStudentSkillCommand>
{
    public DeleteStudentSkillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}