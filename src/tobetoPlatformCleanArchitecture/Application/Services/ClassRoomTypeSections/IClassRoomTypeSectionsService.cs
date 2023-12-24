using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassRoomTypeSections;

public interface IClassRoomTypeSectionsService
{
    Task<ClassRoomTypeSection?> GetAsync(
        Expression<Func<ClassRoomTypeSection, bool>> predicate,
        Func<IQueryable<ClassRoomTypeSection>, IIncludableQueryable<ClassRoomTypeSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ClassRoomTypeSection>?> GetListAsync(
        Expression<Func<ClassRoomTypeSection, bool>>? predicate = null,
        Func<IQueryable<ClassRoomTypeSection>, IOrderedQueryable<ClassRoomTypeSection>>? orderBy = null,
        Func<IQueryable<ClassRoomTypeSection>, IIncludableQueryable<ClassRoomTypeSection, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ClassRoomTypeSection> AddAsync(ClassRoomTypeSection classRoomTypeSection);
    Task<ClassRoomTypeSection> UpdateAsync(ClassRoomTypeSection classRoomTypeSection);
    Task<ClassRoomTypeSection> DeleteAsync(ClassRoomTypeSection classRoomTypeSection, bool permanent = false);
}
