using FluentValidation;

namespace Application.Features.UserSections.Commands.Delete;

public class DeleteUserSectionCommandValidator : AbstractValidator<DeleteUserSectionCommand>
{
    public DeleteUserSectionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}