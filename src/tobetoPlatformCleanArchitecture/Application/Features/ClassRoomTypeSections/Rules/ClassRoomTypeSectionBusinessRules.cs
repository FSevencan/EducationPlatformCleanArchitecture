using Application.Features.ClassRoomTypeSections.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ClassRoomTypeSections.Rules;

public class ClassRoomTypeSectionBusinessRules : BaseBusinessRules
{
    private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;

    public ClassRoomTypeSectionBusinessRules(IClassRoomTypeSectionRepository classRoomTypeSectionRepository)
    {
        _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
    }

    public Task ClassRoomTypeSectionShouldExistWhenSelected(ClassRoomTypeSection? classRoomTypeSection)
    {
        if (classRoomTypeSection == null)
            throw new BusinessException(ClassRoomTypeSectionsBusinessMessages.ClassRoomTypeSectionNotExists);
        return Task.CompletedTask;
    }

    public async Task ClassRoomTypeSectionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ClassRoomTypeSection? classRoomTypeSection = await _classRoomTypeSectionRepository.GetAsync(
            predicate: crts => crts.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ClassRoomTypeSectionShouldExistWhenSelected(classRoomTypeSection);
    }
}