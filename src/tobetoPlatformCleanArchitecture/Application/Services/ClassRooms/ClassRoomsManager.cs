using Application.Features.ClassRooms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassRooms;

public class ClassRoomsManager : IClassRoomsService
{
    private readonly IClassRoomRepository _classRoomRepository;
    private readonly ClassRoomBusinessRules _classRoomBusinessRules;

    public ClassRoomsManager(IClassRoomRepository classRoomRepository, ClassRoomBusinessRules classRoomBusinessRules)
    {
        _classRoomRepository = classRoomRepository;
        _classRoomBusinessRules = classRoomBusinessRules;
    }

    public async Task<ClassRoom?> GetAsync(
        Expression<Func<ClassRoom, bool>> predicate,
        Func<IQueryable<ClassRoom>, IIncludableQueryable<ClassRoom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ClassRoom? classRoom = await _classRoomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return classRoom;
    }

    public async Task<IPaginate<ClassRoom>?> GetListAsync(
        Expression<Func<ClassRoom, bool>>? predicate = null,
        Func<IQueryable<ClassRoom>, IOrderedQueryable<ClassRoom>>? orderBy = null,
        Func<IQueryable<ClassRoom>, IIncludableQueryable<ClassRoom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ClassRoom> classRoomList = await _classRoomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classRoomList;
    }

    public async Task<ClassRoom> AddAsync(ClassRoom classRoom)
    {
        ClassRoom addedClassRoom = await _classRoomRepository.AddAsync(classRoom);

        return addedClassRoom;
    }

    public async Task<ClassRoom> UpdateAsync(ClassRoom classRoom)
    {
        ClassRoom updatedClassRoom = await _classRoomRepository.UpdateAsync(classRoom);

        return updatedClassRoom;
    }

    public async Task<ClassRoom> DeleteAsync(ClassRoom classRoom, bool permanent = false)
    {
        ClassRoom deletedClassRoom = await _classRoomRepository.DeleteAsync(classRoom);

        return deletedClassRoom;
    }
}
