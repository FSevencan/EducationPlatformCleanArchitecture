using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SectionInstructors;

public interface ISectionInstructorsService
{
    Task<SectionInstructor?> GetAsync(
        Expression<Func<SectionInstructor, bool>> predicate,
        Func<IQueryable<SectionInstructor>, IIncludableQueryable<SectionInstructor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SectionInstructor>?> GetListAsync(
        Expression<Func<SectionInstructor, bool>>? predicate = null,
        Func<IQueryable<SectionInstructor>, IOrderedQueryable<SectionInstructor>>? orderBy = null,
        Func<IQueryable<SectionInstructor>, IIncludableQueryable<SectionInstructor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SectionInstructor> AddAsync(SectionInstructor sectionInstructor);
    Task<SectionInstructor> UpdateAsync(SectionInstructor sectionInstructor);
    Task<SectionInstructor> DeleteAsync(SectionInstructor sectionInstructor, bool permanent = false);
}
