using FluentValidation;

namespace Application.Features.StudentSkills.Commands.Update;

public class UpdateStudentSkillCommandValidator : AbstractValidator<UpdateStudentSkillCommand>
{
    public UpdateStudentSkillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.SkillId).NotEmpty();
      
    }
}