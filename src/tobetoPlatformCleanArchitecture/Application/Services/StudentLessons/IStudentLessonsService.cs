using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentLessons;

public interface IStudentLessonsService
{
    Task<StudentLesson?> GetAsync(
        Expression<Func<StudentLesson, bool>> predicate,
        Func<IQueryable<StudentLesson>, IIncludableQueryable<StudentLesson, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentLesson>?> GetListAsync(
        Expression<Func<StudentLesson, bool>>? predicate = null,
        Func<IQueryable<StudentLesson>, IOrderedQueryable<StudentLesson>>? orderBy = null,
        Func<IQueryable<StudentLesson>, IIncludableQueryable<StudentLesson, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentLesson> AddAsync(StudentLesson studentLesson);
    Task<StudentLesson> UpdateAsync(StudentLesson studentLesson);
    Task<StudentLesson> DeleteAsync(StudentLesson studentLesson, bool permanent = false);
}
