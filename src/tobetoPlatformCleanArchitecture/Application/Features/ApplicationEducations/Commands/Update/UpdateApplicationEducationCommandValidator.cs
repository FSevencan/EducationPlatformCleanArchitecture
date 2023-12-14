using FluentValidation;

namespace Application.Features.ApplicationEducations.Commands.Update;

public class UpdateApplicationEducationCommandValidator : AbstractValidator<UpdateApplicationEducationCommand>
{
    public UpdateApplicationEducationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}