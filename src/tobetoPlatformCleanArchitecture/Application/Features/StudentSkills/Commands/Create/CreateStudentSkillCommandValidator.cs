using FluentValidation;

namespace Application.Features.StudentSkills.Commands.Create;

public class CreateStudentSkillCommandValidator : AbstractValidator<CreateStudentSkillCommand>
{
    public CreateStudentSkillCommandValidator()
    {
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SkillId).NotEmpty();
        RuleFor(c => c.Student).NotEmpty();
        RuleFor(c => c.Skill).NotEmpty();
    }
}