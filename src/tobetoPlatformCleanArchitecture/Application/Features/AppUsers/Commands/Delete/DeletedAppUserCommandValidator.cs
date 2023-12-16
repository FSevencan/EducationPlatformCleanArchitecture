using FluentValidation;

namespace Application.Features.AppUsers.Commands.Delete;

public class DeleteAppUserCommandValidator : AbstractValidator<DeleteAppUserCommand>
{
    public DeleteAppUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}