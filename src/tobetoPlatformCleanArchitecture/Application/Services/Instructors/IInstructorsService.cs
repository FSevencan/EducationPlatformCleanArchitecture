using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Instructors;

public interface IInstructorsService
{
    Task<Instructor?> GetAsync(
        Expression<Func<Instructor, bool>> predicate,
        Func<IQueryable<Instructor>, IIncludableQueryable<Instructor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Instructor>?> GetListAsync(
        Expression<Func<Instructor, bool>>? predicate = null,
        Func<IQueryable<Instructor>, IOrderedQueryable<Instructor>>? orderBy = null,
        Func<IQueryable<Instructor>, IIncludableQueryable<Instructor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Instructor> AddAsync(Instructor instructor);
    Task<Instructor> UpdateAsync(Instructor instructor);
    Task<Instructor> DeleteAsync(Instructor instructor, bool permanent = false);
}
