using Application.Features.ProducerCompanies.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProducerCompanies;

public class ProducerCompaniesManager : IProducerCompaniesService
{
    private readonly IProducerCompanyRepository _producerCompanyRepository;
    private readonly ProducerCompanyBusinessRules _producerCompanyBusinessRules;

    public ProducerCompaniesManager(IProducerCompanyRepository producerCompanyRepository, ProducerCompanyBusinessRules producerCompanyBusinessRules)
    {
        _producerCompanyRepository = producerCompanyRepository;
        _producerCompanyBusinessRules = producerCompanyBusinessRules;
    }

    public async Task<ProducerCompany?> GetAsync(
        Expression<Func<ProducerCompany, bool>> predicate,
        Func<IQueryable<ProducerCompany>, IIncludableQueryable<ProducerCompany, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProducerCompany? producerCompany = await _producerCompanyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return producerCompany;
    }

    public async Task<IPaginate<ProducerCompany>?> GetListAsync(
        Expression<Func<ProducerCompany, bool>>? predicate = null,
        Func<IQueryable<ProducerCompany>, IOrderedQueryable<ProducerCompany>>? orderBy = null,
        Func<IQueryable<ProducerCompany>, IIncludableQueryable<ProducerCompany, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProducerCompany> producerCompanyList = await _producerCompanyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return producerCompanyList;
    }

    public async Task<ProducerCompany> AddAsync(ProducerCompany producerCompany)
    {
        ProducerCompany addedProducerCompany = await _producerCompanyRepository.AddAsync(producerCompany);

        return addedProducerCompany;
    }

    public async Task<ProducerCompany> UpdateAsync(ProducerCompany producerCompany)
    {
        ProducerCompany updatedProducerCompany = await _producerCompanyRepository.UpdateAsync(producerCompany);

        return updatedProducerCompany;
    }

    public async Task<ProducerCompany> DeleteAsync(ProducerCompany producerCompany, bool permanent = false)
    {
        ProducerCompany deletedProducerCompany = await _producerCompanyRepository.DeleteAsync(producerCompany);

        return deletedProducerCompany;
    }
}
