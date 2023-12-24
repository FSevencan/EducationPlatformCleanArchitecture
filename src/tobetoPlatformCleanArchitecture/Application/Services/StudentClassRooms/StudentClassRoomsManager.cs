using Application.Features.StudentClassRooms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentClassRooms;

public class StudentClassRoomsManager : IStudentClassRoomsService
{
    private readonly IStudentClassRoomRepository _studentClassRoomRepository;
    private readonly StudentClassRoomBusinessRules _studentClassRoomBusinessRules;

    public StudentClassRoomsManager(IStudentClassRoomRepository studentClassRoomRepository, StudentClassRoomBusinessRules studentClassRoomBusinessRules)
    {
        _studentClassRoomRepository = studentClassRoomRepository;
        _studentClassRoomBusinessRules = studentClassRoomBusinessRules;
    }

    public async Task<ClassRoomTypeSection?> GetAsync(
        Expression<Func<ClassRoomTypeSection, bool>> predicate,
        Func<IQueryable<ClassRoomTypeSection>, IIncludableQueryable<ClassRoomTypeSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ClassRoomTypeSection? studentClassRoom = await _studentClassRoomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentClassRoom;
    }

    public async Task<IPaginate<ClassRoomTypeSection>?> GetListAsync(
        Expression<Func<ClassRoomTypeSection, bool>>? predicate = null,
        Func<IQueryable<ClassRoomTypeSection>, IOrderedQueryable<ClassRoomTypeSection>>? orderBy = null,
        Func<IQueryable<ClassRoomTypeSection>, IIncludableQueryable<ClassRoomTypeSection, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ClassRoomTypeSection> studentClassRoomList = await _studentClassRoomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentClassRoomList;
    }

    public async Task<ClassRoomTypeSection> AddAsync(ClassRoomTypeSection studentClassRoom)
    {
        ClassRoomTypeSection addedStudentClassRoom = await _studentClassRoomRepository.AddAsync(studentClassRoom);

        return addedStudentClassRoom;
    }

    public async Task<ClassRoomTypeSection> UpdateAsync(ClassRoomTypeSection studentClassRoom)
    {
        ClassRoomTypeSection updatedStudentClassRoom = await _studentClassRoomRepository.UpdateAsync(studentClassRoom);

        return updatedStudentClassRoom;
    }

    public async Task<ClassRoomTypeSection> DeleteAsync(ClassRoomTypeSection studentClassRoom, bool permanent = false)
    {
        ClassRoomTypeSection deletedStudentClassRoom = await _studentClassRoomRepository.DeleteAsync(studentClassRoom);

        return deletedStudentClassRoom;
    }
}
