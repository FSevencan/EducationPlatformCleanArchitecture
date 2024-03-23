using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassRooms;

public interface IClassRoomsService
{
    Task<ClassRoom?> GetAsync(
        Expression<Func<ClassRoom, bool>> predicate,
        Func<IQueryable<ClassRoom>, IIncludableQueryable<ClassRoom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ClassRoom>?> GetListAsync(
        Expression<Func<ClassRoom, bool>>? predicate = null,
        Func<IQueryable<ClassRoom>, IOrderedQueryable<ClassRoom>>? orderBy = null,
        Func<IQueryable<ClassRoom>, IIncludableQueryable<ClassRoom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ClassRoom> AddAsync(ClassRoom classRoom);
    Task<ClassRoom> UpdateAsync(ClassRoom classRoom);
    Task<ClassRoom> DeleteAsync(ClassRoom classRoom, bool permanent = false);
}
