using Application.Features.ClassRoomTypes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ClassRoomTypes.Rules;

public class ClassRoomTypeBusinessRules : BaseBusinessRules
{
    private readonly IClassRoomTypeRepository _classRoomTypeRepository;

    public ClassRoomTypeBusinessRules(IClassRoomTypeRepository classRoomTypeRepository)
    {
        _classRoomTypeRepository = classRoomTypeRepository;
    }

    public Task ClassRoomTypeShouldExistWhenSelected(ClassRoomType? classRoomType)
    {
        if (classRoomType == null)
            throw new BusinessException(ClassRoomTypesBusinessMessages.ClassRoomTypeNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassRoomTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ClassRoomType? classRoomType = await _classRoomTypeRepository.GetAsync(
            predicate: crt => crt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassRoomTypeShouldExistWhenSelected(classRoomType);
    }
}