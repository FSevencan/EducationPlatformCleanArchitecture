using FluentValidation;

namespace Application.Features.StudentSkills.Commands.Create;

public class CreateStudentSkillCommandValidator : AbstractValidator<CreateStudentSkillCommand>
{
    public CreateStudentSkillCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.Skills).NotEmpty();      
    }
}