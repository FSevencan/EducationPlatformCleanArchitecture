using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SectionAbouts;

public interface ISectionAboutsService
{
    Task<SectionAbout?> GetAsync(
        Expression<Func<SectionAbout, bool>> predicate,
        Func<IQueryable<SectionAbout>, IIncludableQueryable<SectionAbout, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SectionAbout>?> GetListAsync(
        Expression<Func<SectionAbout, bool>>? predicate = null,
        Func<IQueryable<SectionAbout>, IOrderedQueryable<SectionAbout>>? orderBy = null,
        Func<IQueryable<SectionAbout>, IIncludableQueryable<SectionAbout, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SectionAbout> AddAsync(SectionAbout sectionAbout);
    Task<SectionAbout> UpdateAsync(SectionAbout sectionAbout);
    Task<SectionAbout> DeleteAsync(SectionAbout sectionAbout, bool permanent = false);
}
