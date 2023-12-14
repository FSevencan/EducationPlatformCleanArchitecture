using FluentValidation;

namespace Application.Features.ApplicationEducations.Commands.Create;

public class CreateApplicationEducationCommandValidator : AbstractValidator<CreateApplicationEducationCommand>
{
    public CreateApplicationEducationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}