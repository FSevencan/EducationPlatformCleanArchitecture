using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SectionCourses;

public interface ISectionCoursesService
{
    Task<SectionCourse?> GetAsync(
        Expression<Func<SectionCourse, bool>> predicate,
        Func<IQueryable<SectionCourse>, IIncludableQueryable<SectionCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SectionCourse>?> GetListAsync(
        Expression<Func<SectionCourse, bool>>? predicate = null,
        Func<IQueryable<SectionCourse>, IOrderedQueryable<SectionCourse>>? orderBy = null,
        Func<IQueryable<SectionCourse>, IIncludableQueryable<SectionCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SectionCourse> AddAsync(SectionCourse sectionCourse);
    Task<SectionCourse> UpdateAsync(SectionCourse sectionCourse);
    Task<SectionCourse> DeleteAsync(SectionCourse sectionCourse, bool permanent = false);
}
