using Application.Features.StudentClassRooms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentClassRooms.Rules;

public class StudentClassRoomBusinessRules : BaseBusinessRules
{
    private readonly IStudentClassRoomRepository _studentClassRoomRepository;

    public StudentClassRoomBusinessRules(IStudentClassRoomRepository studentClassRoomRepository)
    {
        _studentClassRoomRepository = studentClassRoomRepository;
    }

    public Task StudentClassRoomShouldExistWhenSelected(StudentClassRoom? studentClassRoom)
    {
        if (studentClassRoom == null)
            throw new BusinessException(StudentClassRoomsBusinessMessages.StudentClassRoomNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentClassRoomIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentClassRoom? studentClassRoom = await _studentClassRoomRepository.GetAsync(
            predicate: scr => scr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentClassRoomShouldExistWhenSelected(studentClassRoom);
    }

    public Task StudentShouldBeAssignedToClassRoom(Student student)
    {
        if (student.StudentClassRooms == null || !student.StudentClassRooms.Any())
            throw new BusinessException("Abone olabilmek için sýnýf atamanýzýn yapýlmasý gerekmektedir.");

        return Task.CompletedTask;
    }

}