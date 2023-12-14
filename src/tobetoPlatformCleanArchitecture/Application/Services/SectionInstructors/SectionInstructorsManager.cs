using Application.Features.SectionInstructors.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SectionInstructors;

public class SectionInstructorsManager : ISectionInstructorsService
{
    private readonly ISectionInstructorRepository _sectionInstructorRepository;
    private readonly SectionInstructorBusinessRules _sectionInstructorBusinessRules;

    public SectionInstructorsManager(ISectionInstructorRepository sectionInstructorRepository, SectionInstructorBusinessRules sectionInstructorBusinessRules)
    {
        _sectionInstructorRepository = sectionInstructorRepository;
        _sectionInstructorBusinessRules = sectionInstructorBusinessRules;
    }

    public async Task<SectionInstructor?> GetAsync(
        Expression<Func<SectionInstructor, bool>> predicate,
        Func<IQueryable<SectionInstructor>, IIncludableQueryable<SectionInstructor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SectionInstructor? sectionInstructor = await _sectionInstructorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sectionInstructor;
    }

    public async Task<IPaginate<SectionInstructor>?> GetListAsync(
        Expression<Func<SectionInstructor, bool>>? predicate = null,
        Func<IQueryable<SectionInstructor>, IOrderedQueryable<SectionInstructor>>? orderBy = null,
        Func<IQueryable<SectionInstructor>, IIncludableQueryable<SectionInstructor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SectionInstructor> sectionInstructorList = await _sectionInstructorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sectionInstructorList;
    }

    public async Task<SectionInstructor> AddAsync(SectionInstructor sectionInstructor)
    {
        SectionInstructor addedSectionInstructor = await _sectionInstructorRepository.AddAsync(sectionInstructor);

        return addedSectionInstructor;
    }

    public async Task<SectionInstructor> UpdateAsync(SectionInstructor sectionInstructor)
    {
        SectionInstructor updatedSectionInstructor = await _sectionInstructorRepository.UpdateAsync(sectionInstructor);

        return updatedSectionInstructor;
    }

    public async Task<SectionInstructor> DeleteAsync(SectionInstructor sectionInstructor, bool permanent = false)
    {
        SectionInstructor deletedSectionInstructor = await _sectionInstructorRepository.DeleteAsync(sectionInstructor);

        return deletedSectionInstructor;
    }
}
