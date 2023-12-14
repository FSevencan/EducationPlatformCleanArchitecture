using FluentValidation;

namespace Application.Features.UserSections.Commands.Update;

public class UpdateUserSectionCommandValidator : AbstractValidator<UpdateUserSectionCommand>
{
    public UpdateUserSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SectionId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}