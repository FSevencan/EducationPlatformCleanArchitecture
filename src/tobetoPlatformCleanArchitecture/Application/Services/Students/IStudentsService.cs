using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Students;

public interface IStudentsService
{
    Task<Student?> GetAsync(
        Expression<Func<Student, bool>> predicate,
        Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Student>?> GetListAsync(
        Expression<Func<Student, bool>>? predicate = null,
        Func<IQueryable<Student>, IOrderedQueryable<Student>>? orderBy = null,
        Func<IQueryable<Student>, IIncludableQueryable<Student, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Student> AddAsync(Student student);
    Task<Student> UpdateAsync(Student student);
    Task<Student> DeleteAsync(Student student, bool permanent = false);
}
