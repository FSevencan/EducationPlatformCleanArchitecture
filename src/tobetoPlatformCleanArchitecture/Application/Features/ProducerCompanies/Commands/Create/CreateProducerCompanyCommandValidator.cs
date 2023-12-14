using FluentValidation;

namespace Application.Features.ProducerCompanies.Commands.Create;

public class CreateProducerCompanyCommandValidator : AbstractValidator<CreateProducerCompanyCommand>
{
    public CreateProducerCompanyCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}