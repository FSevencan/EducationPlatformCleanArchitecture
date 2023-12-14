using FluentValidation;

namespace Application.Features.UserSections.Commands.Create;

public class CreateUserSectionCommandValidator : AbstractValidator<CreateUserSectionCommand>
{
    public CreateUserSectionCommandValidator()
    {
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}