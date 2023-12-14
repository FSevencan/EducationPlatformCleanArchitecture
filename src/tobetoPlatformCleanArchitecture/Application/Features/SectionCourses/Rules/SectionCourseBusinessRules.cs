using Application.Features.SectionCourses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SectionCourses.Rules;

public class SectionCourseBusinessRules : BaseBusinessRules
{
    private readonly ISectionCourseRepository _sectionCourseRepository;

    public SectionCourseBusinessRules(ISectionCourseRepository sectionCourseRepository)
    {
        _sectionCourseRepository = sectionCourseRepository;
    }

    public Task SectionCourseShouldExistWhenSelected(SectionCourse? sectionCourse)
    {
        if (sectionCourse == null)
            throw new BusinessException(SectionCoursesBusinessMessages.SectionCourseNotExists);
        return Task.CompletedTask;
    }

    public async Task SectionCourseIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SectionCourse? sectionCourse = await _sectionCourseRepository.GetAsync(
            predicate: sc => sc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SectionCourseShouldExistWhenSelected(sectionCourse);
    }
}