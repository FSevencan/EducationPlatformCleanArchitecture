using FluentValidation;

namespace Application.Features.Contacts.Commands.Update;

public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
{
    public UpdateContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.ReadDate).NotEmpty();
    }
}