using Application.Features.ClassRooms.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ClassRooms.Rules;

public class ClassRoomBusinessRules : BaseBusinessRules
{
    private readonly IClassRoomRepository _classRoomRepository;

    public ClassRoomBusinessRules(IClassRoomRepository classRoomRepository)
    {
        _classRoomRepository = classRoomRepository;
    }

    public Task ClassRoomShouldExistWhenSelected(ClassRoom? classRoom)
    {
        if (classRoom == null)
            throw new BusinessException(ClassRoomsBusinessMessages.ClassRoomNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassRoomIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ClassRoom? classRoom = await _classRoomRepository.GetAsync(
            predicate: cr => cr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassRoomShouldExistWhenSelected(classRoom);
    }
}