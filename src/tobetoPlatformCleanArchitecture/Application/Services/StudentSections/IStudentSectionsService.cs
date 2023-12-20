using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentSections;

public interface IStudentSectionsService
{
    Task<StudentSection?> GetAsync(
        Expression<Func<StudentSection, bool>> predicate,
        Func<IQueryable<StudentSection>, IIncludableQueryable<StudentSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentSection>?> GetListAsync(
        Expression<Func<StudentSection, bool>>? predicate = null,
        Func<IQueryable<StudentSection>, IOrderedQueryable<StudentSection>>? orderBy = null,
        Func<IQueryable<StudentSection>, IIncludableQueryable<StudentSection, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentSection> AddAsync(StudentSection studentSection);
    Task<StudentSection> UpdateAsync(StudentSection studentSection);
    Task<StudentSection> DeleteAsync(StudentSection studentSection, bool permanent = false);
}
