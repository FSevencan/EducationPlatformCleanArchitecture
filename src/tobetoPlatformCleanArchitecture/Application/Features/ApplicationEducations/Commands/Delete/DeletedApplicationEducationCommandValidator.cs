using FluentValidation;

namespace Application.Features.ApplicationEducations.Commands.Delete;

public class DeleteApplicationEducationCommandValidator : AbstractValidator<DeleteApplicationEducationCommand>
{
    public DeleteApplicationEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}