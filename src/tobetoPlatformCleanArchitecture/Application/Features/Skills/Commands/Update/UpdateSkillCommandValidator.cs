using FluentValidation;

namespace Application.Features.Skills.Commands.Update;

public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
{
    public UpdateSkillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Level).NotEmpty();
    }
}