using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sections;

public interface ISectionsService
{
    Task<Section?> GetAsync(
        Expression<Func<Section, bool>> predicate,
        Func<IQueryable<Section>, IIncludableQueryable<Section, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Section>?> GetListAsync(
        Expression<Func<Section, bool>>? predicate = null,
        Func<IQueryable<Section>, IOrderedQueryable<Section>>? orderBy = null,
        Func<IQueryable<Section>, IIncludableQueryable<Section, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Section> AddAsync(Section section);
    Task<Section> UpdateAsync(Section section);
    Task<Section> DeleteAsync(Section section, bool permanent = false);
}
