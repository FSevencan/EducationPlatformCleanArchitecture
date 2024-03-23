using FluentValidation;

namespace Application.Features.Skills.Commands.Delete;

public class DeleteSkillCommandValidator : AbstractValidator<DeleteSkillCommand>
{
    public DeleteSkillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}