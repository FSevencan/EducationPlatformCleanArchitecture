using FluentValidation;

namespace Application.Features.ProducerCompanies.Commands.Delete;

public class DeleteProducerCompanyCommandValidator : AbstractValidator<DeleteProducerCompanyCommand>
{
    public DeleteProducerCompanyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}