using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationEducations;

public interface IApplicationEducationsService
{
    Task<ApplicationEducation?> GetAsync(
        Expression<Func<ApplicationEducation, bool>> predicate,
        Func<IQueryable<ApplicationEducation>, IIncludableQueryable<ApplicationEducation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ApplicationEducation>?> GetListAsync(
        Expression<Func<ApplicationEducation, bool>>? predicate = null,
        Func<IQueryable<ApplicationEducation>, IOrderedQueryable<ApplicationEducation>>? orderBy = null,
        Func<IQueryable<ApplicationEducation>, IIncludableQueryable<ApplicationEducation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ApplicationEducation> AddAsync(ApplicationEducation applicationEducation);
    Task<ApplicationEducation> UpdateAsync(ApplicationEducation applicationEducation);
    Task<ApplicationEducation> DeleteAsync(ApplicationEducation applicationEducation, bool permanent = false);
}
