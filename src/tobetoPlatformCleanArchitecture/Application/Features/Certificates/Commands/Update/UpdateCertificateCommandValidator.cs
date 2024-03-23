using FluentValidation;

namespace Application.Features.Certificates.Commands.Update;

public class UpdateCertificateCommandValidator : AbstractValidator<UpdateCertificateCommand>
{
    public UpdateCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Image).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.Student).NotEmpty();
    }
}