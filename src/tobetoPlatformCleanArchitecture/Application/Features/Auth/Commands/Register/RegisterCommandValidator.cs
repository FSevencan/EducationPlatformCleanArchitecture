using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.AppUserForRegisterDto.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.AppUserForRegisterDto.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.AppUserForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.AppUserForRegisterDto.Password).NotEmpty().MinimumLength(4);
    }
}
