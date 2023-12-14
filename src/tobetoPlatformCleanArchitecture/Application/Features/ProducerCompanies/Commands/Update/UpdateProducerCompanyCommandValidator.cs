using FluentValidation;

namespace Application.Features.ProducerCompanies.Commands.Update;

public class UpdateProducerCompanyCommandValidator : AbstractValidator<UpdateProducerCompanyCommand>
{
    public UpdateProducerCompanyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}