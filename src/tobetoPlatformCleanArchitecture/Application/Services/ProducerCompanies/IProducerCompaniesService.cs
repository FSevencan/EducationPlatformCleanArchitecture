using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProducerCompanies;

public interface IProducerCompaniesService
{
    Task<ProducerCompany?> GetAsync(
        Expression<Func<ProducerCompany, bool>> predicate,
        Func<IQueryable<ProducerCompany>, IIncludableQueryable<ProducerCompany, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProducerCompany>?> GetListAsync(
        Expression<Func<ProducerCompany, bool>>? predicate = null,
        Func<IQueryable<ProducerCompany>, IOrderedQueryable<ProducerCompany>>? orderBy = null,
        Func<IQueryable<ProducerCompany>, IIncludableQueryable<ProducerCompany, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProducerCompany> AddAsync(ProducerCompany producerCompany);
    Task<ProducerCompany> UpdateAsync(ProducerCompany producerCompany);
    Task<ProducerCompany> DeleteAsync(ProducerCompany producerCompany, bool permanent = false);
}
