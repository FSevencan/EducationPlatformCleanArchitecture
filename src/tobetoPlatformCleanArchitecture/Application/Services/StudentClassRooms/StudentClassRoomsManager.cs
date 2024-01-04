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

    public async Task<StudentClassRoom?> GetAsync(
        Expression<Func<StudentClassRoom, bool>> predicate,
        Func<IQueryable<StudentClassRoom>, IIncludableQueryable<StudentClassRoom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentClassRoom? studentClassRoom = await _studentClassRoomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentClassRoom;
    }

    public async Task<IPaginate<StudentClassRoom>?> GetListAsync(
        Expression<Func<StudentClassRoom, bool>>? predicate = null,
        Func<IQueryable<StudentClassRoom>, IOrderedQueryable<StudentClassRoom>>? orderBy = null,
        Func<IQueryable<StudentClassRoom>, IIncludableQueryable<StudentClassRoom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentClassRoom> studentClassRoomList = await _studentClassRoomRepository.GetListAsync(
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

    public async Task<StudentClassRoom> AddAsync(StudentClassRoom studentClassRoom)
    {
        StudentClassRoom addedStudentClassRoom = await _studentClassRoomRepository.AddAsync(studentClassRoom);

        return addedStudentClassRoom;
    }

    public async Task<StudentClassRoom> UpdateAsync(StudentClassRoom studentClassRoom)
    {
        StudentClassRoom updatedStudentClassRoom = await _studentClassRoomRepository.UpdateAsync(studentClassRoom);

        return updatedStudentClassRoom;
    }

    public async Task<StudentClassRoom> DeleteAsync(StudentClassRoom studentClassRoom, bool permanent = false)
    {
        StudentClassRoom deletedStudentClassRoom = await _studentClassRoomRepository.DeleteAsync(studentClassRoom);

        return deletedStudentClassRoom;
    }
}
