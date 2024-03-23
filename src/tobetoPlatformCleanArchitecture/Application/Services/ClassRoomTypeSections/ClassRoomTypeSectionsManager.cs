using Application.Features.ClassRoomTypeSections.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassRoomTypeSections;

public class ClassRoomTypeSectionsManager : IClassRoomTypeSectionsService
{
    private readonly IClassRoomTypeSectionRepository _classRoomTypeSectionRepository;
    private readonly ClassRoomTypeSectionBusinessRules _classRoomTypeSectionBusinessRules;

    public ClassRoomTypeSectionsManager(IClassRoomTypeSectionRepository classRoomTypeSectionRepository, ClassRoomTypeSectionBusinessRules classRoomTypeSectionBusinessRules)
    {
        _classRoomTypeSectionRepository = classRoomTypeSectionRepository;
        _classRoomTypeSectionBusinessRules = classRoomTypeSectionBusinessRules;
    }

    public async Task<ClassRoomTypeSection?> GetAsync(
        Expression<Func<ClassRoomTypeSection, bool>> predicate,
        Func<IQueryable<ClassRoomTypeSection>, IIncludableQueryable<ClassRoomTypeSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ClassRoomTypeSection? classRoomTypeSection = await _classRoomTypeSectionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return classRoomTypeSection;
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
        IPaginate<ClassRoomTypeSection> classRoomTypeSectionList = await _classRoomTypeSectionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classRoomTypeSectionList;
    }

    public async Task<ClassRoomTypeSection> AddAsync(ClassRoomTypeSection classRoomTypeSection)
    {
        ClassRoomTypeSection addedClassRoomTypeSection = await _classRoomTypeSectionRepository.AddAsync(classRoomTypeSection);

        return addedClassRoomTypeSection;
    }

    public async Task<ClassRoomTypeSection> UpdateAsync(ClassRoomTypeSection classRoomTypeSection)
    {
        ClassRoomTypeSection updatedClassRoomTypeSection = await _classRoomTypeSectionRepository.UpdateAsync(classRoomTypeSection);

        return updatedClassRoomTypeSection;
    }

    public async Task<ClassRoomTypeSection> DeleteAsync(ClassRoomTypeSection classRoomTypeSection, bool permanent = false)
    {
        ClassRoomTypeSection deletedClassRoomTypeSection = await _classRoomTypeSectionRepository.DeleteAsync(classRoomTypeSection);

        return deletedClassRoomTypeSection;
    }
}
