using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentClassRooms;

public interface IStudentClassRoomsService
{
    Task<StudentClassRoom?> GetAsync(
        Expression<Func<StudentClassRoom, bool>> predicate,
        Func<IQueryable<StudentClassRoom>, IIncludableQueryable<StudentClassRoom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentClassRoom>?> GetListAsync(
        Expression<Func<StudentClassRoom, bool>>? predicate = null,
        Func<IQueryable<StudentClassRoom>, IOrderedQueryable<StudentClassRoom>>? orderBy = null,
        Func<IQueryable<StudentClassRoom>, IIncludableQueryable<StudentClassRoom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentClassRoom> AddAsync(StudentClassRoom studentClassRoom);
    Task<StudentClassRoom> UpdateAsync(StudentClassRoom studentClassRoom);
    Task<StudentClassRoom> DeleteAsync(StudentClassRoom studentClassRoom, bool permanent = false);
}
