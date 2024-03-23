using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassRoomTypes;

public interface IClassRoomTypesService
{
    Task<ClassRoomType?> GetAsync(
        Expression<Func<ClassRoomType, bool>> predicate,
        Func<IQueryable<ClassRoomType>, IIncludableQueryable<ClassRoomType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ClassRoomType>?> GetListAsync(
        Expression<Func<ClassRoomType, bool>>? predicate = null,
        Func<IQueryable<ClassRoomType>, IOrderedQueryable<ClassRoomType>>? orderBy = null,
        Func<IQueryable<ClassRoomType>, IIncludableQueryable<ClassRoomType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ClassRoomType> AddAsync(ClassRoomType classRoomType);
    Task<ClassRoomType> UpdateAsync(ClassRoomType classRoomType);
    Task<ClassRoomType> DeleteAsync(ClassRoomType classRoomType, bool permanent = false);
}
