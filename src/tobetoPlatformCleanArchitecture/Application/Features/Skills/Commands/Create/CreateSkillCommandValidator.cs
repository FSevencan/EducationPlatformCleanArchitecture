using FluentValidation;

namespace Application.Features.Skills.Commands.Create;

public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Level).NotEmpty();
    }
}