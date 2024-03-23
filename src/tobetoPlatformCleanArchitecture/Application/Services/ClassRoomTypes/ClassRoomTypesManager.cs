using Application.Features.ClassRoomTypes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ClassRoomTypes;

public class ClassRoomTypesManager : IClassRoomTypesService
{
    private readonly IClassRoomTypeRepository _classRoomTypeRepository;
    private readonly ClassRoomTypeBusinessRules _classRoomTypeBusinessRules;

    public ClassRoomTypesManager(IClassRoomTypeRepository classRoomTypeRepository, ClassRoomTypeBusinessRules classRoomTypeBusinessRules)
    {
        _classRoomTypeRepository = classRoomTypeRepository;
        _classRoomTypeBusinessRules = classRoomTypeBusinessRules;
    }

    public async Task<ClassRoomType?> GetAsync(
        Expression<Func<ClassRoomType, bool>> predicate,
        Func<IQueryable<ClassRoomType>, IIncludableQueryable<ClassRoomType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ClassRoomType? classRoomType = await _classRoomTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return classRoomType;
    }

    public async Task<IPaginate<ClassRoomType>?> GetListAsync(
        Expression<Func<ClassRoomType, bool>>? predicate = null,
        Func<IQueryable<ClassRoomType>, IOrderedQueryable<ClassRoomType>>? orderBy = null,
        Func<IQueryable<ClassRoomType>, IIncludableQueryable<ClassRoomType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ClassRoomType> classRoomTypeList = await _classRoomTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return classRoomTypeList;
    }

    public async Task<ClassRoomType> AddAsync(ClassRoomType classRoomType)
    {
        ClassRoomType addedClassRoomType = await _classRoomTypeRepository.AddAsync(classRoomType);

        return addedClassRoomType;
    }

    public async Task<ClassRoomType> UpdateAsync(ClassRoomType classRoomType)
    {
        ClassRoomType updatedClassRoomType = await _classRoomTypeRepository.UpdateAsync(classRoomType);

        return updatedClassRoomType;
    }

    public async Task<ClassRoomType> DeleteAsync(ClassRoomType classRoomType, bool permanent = false)
    {
        ClassRoomType deletedClassRoomType = await _classRoomTypeRepository.DeleteAsync(classRoomType);

        return deletedClassRoomType;
    }
}
