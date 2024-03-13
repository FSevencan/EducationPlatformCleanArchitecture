using FluentValidation;

namespace Application.Features.Contacts.Commands.Delete;

public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}