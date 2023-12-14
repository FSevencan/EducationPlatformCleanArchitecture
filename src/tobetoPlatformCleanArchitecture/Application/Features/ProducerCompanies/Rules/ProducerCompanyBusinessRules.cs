using Application.Features.ProducerCompanies.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProducerCompanies.Rules;

public class ProducerCompanyBusinessRules : BaseBusinessRules
{
    private readonly IProducerCompanyRepository _producerCompanyRepository;

    public ProducerCompanyBusinessRules(IProducerCompanyRepository producerCompanyRepository)
    {
        _producerCompanyRepository = producerCompanyRepository;
    }

    public Task ProducerCompanyShouldExistWhenSelected(ProducerCompany? producerCompany)
    {
        if (producerCompany == null)
            throw new BusinessException(ProducerCompaniesBusinessMessages.ProducerCompanyNotExists);
        return Task.CompletedTask;
    }

    public async Task ProducerCompanyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProducerCompany? producerCompany = await _producerCompanyRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProducerCompanyShouldExistWhenSelected(producerCompany);
    }
}