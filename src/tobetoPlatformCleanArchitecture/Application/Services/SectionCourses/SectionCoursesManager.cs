using Application.Features.SectionCourses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SectionCourses;

public class SectionCoursesManager : ISectionCoursesService
{
    private readonly ISectionCourseRepository _sectionCourseRepository;
    private readonly SectionCourseBusinessRules _sectionCourseBusinessRules;

    public SectionCoursesManager(ISectionCourseRepository sectionCourseRepository, SectionCourseBusinessRules sectionCourseBusinessRules)
    {
        _sectionCourseRepository = sectionCourseRepository;
        _sectionCourseBusinessRules = sectionCourseBusinessRules;
    }

    public async Task<SectionCourse?> GetAsync(
        Expression<Func<SectionCourse, bool>> predicate,
        Func<IQueryable<SectionCourse>, IIncludableQueryable<SectionCourse, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SectionCourse? sectionCourse = await _sectionCourseRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sectionCourse;
    }

    public async Task<IPaginate<SectionCourse>?> GetListAsync(
        Expression<Func<SectionCourse, bool>>? predicate = null,
        Func<IQueryable<SectionCourse>, IOrderedQueryable<SectionCourse>>? orderBy = null,
        Func<IQueryable<SectionCourse>, IIncludableQueryable<SectionCourse, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SectionCourse> sectionCourseList = await _sectionCourseRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sectionCourseList;
    }

    public async Task<SectionCourse> AddAsync(SectionCourse sectionCourse)
    {
        SectionCourse addedSectionCourse = await _sectionCourseRepository.AddAsync(sectionCourse);

        return addedSectionCourse;
    }

    public async Task<SectionCourse> UpdateAsync(SectionCourse sectionCourse)
    {
        SectionCourse updatedSectionCourse = await _sectionCourseRepository.UpdateAsync(sectionCourse);

        return updatedSectionCourse;
    }

    public async Task<SectionCourse> DeleteAsync(SectionCourse sectionCourse, bool permanent = false)
    {
        SectionCourse deletedSectionCourse = await _sectionCourseRepository.DeleteAsync(sectionCourse);

        return deletedSectionCourse;
    }
}
