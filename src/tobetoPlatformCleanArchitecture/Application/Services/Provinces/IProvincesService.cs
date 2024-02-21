using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Provinces;

public interface IProvincesService
{
    Task<Province?> GetAsync(
        Expression<Func<Province, bool>> predicate,
        Func<IQueryable<Province>, IIncludableQueryable<Province, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Province>?> GetListAsync(
        Expression<Func<Province, bool>>? predicate = null,
        Func<IQueryable<Province>, IOrderedQueryable<Province>>? orderBy = null,
        Func<IQueryable<Province>, IIncludableQueryable<Province, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Province> AddAsync(Province province);
    Task<Province> UpdateAsync(Province province);
    Task<Province> DeleteAsync(Province province, bool permanent = false);
}
