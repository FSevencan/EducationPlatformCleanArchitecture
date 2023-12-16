using FluentValidation;

namespace Application.Features.AppUsers.Commands.Update;

public class UpdateAppUserCommandValidator : AbstractValidator<UpdateAppUserCommand>
{
    public UpdateAppUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.AuthenticatorType).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.About).NotEmpty();
        RuleFor(c => c.GithubUrl).NotEmpty();
        RuleFor(c => c.LinkedinUrl).NotEmpty();
    }
}