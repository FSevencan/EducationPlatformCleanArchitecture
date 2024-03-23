using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CampusEncounters;

public interface ICampusEncountersService
{
    Task<CampusEncounter?> GetAsync(
        Expression<Func<CampusEncounter, bool>> predicate,
        Func<IQueryable<CampusEncounter>, IIncludableQueryable<CampusEncounter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CampusEncounter>?> GetListAsync(
        Expression<Func<CampusEncounter, bool>>? predicate = null,
        Func<IQueryable<CampusEncounter>, IOrderedQueryable<CampusEncounter>>? orderBy = null,
        Func<IQueryable<CampusEncounter>, IIncludableQueryable<CampusEncounter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CampusEncounter> AddAsync(CampusEncounter campusEncounter);
    Task<CampusEncounter> UpdateAsync(CampusEncounter campusEncounter);
    Task<CampusEncounter> DeleteAsync(CampusEncounter campusEncounter, bool permanent = false);
}
