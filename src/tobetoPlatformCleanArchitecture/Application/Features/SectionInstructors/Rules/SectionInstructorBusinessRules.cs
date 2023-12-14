using Application.Features.SectionInstructors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SectionInstructors.Rules;

public class SectionInstructorBusinessRules : BaseBusinessRules
{
    private readonly ISectionInstructorRepository _sectionInstructorRepository;

    public SectionInstructorBusinessRules(ISectionInstructorRepository sectionInstructorRepository)
    {
        _sectionInstructorRepository = sectionInstructorRepository;
    }

    public Task SectionInstructorShouldExistWhenSelected(SectionInstructor? sectionInstructor)
    {
        if (sectionInstructor == null)
            throw new BusinessException(SectionInstructorsBusinessMessages.SectionInstructorNotExists);
        return Task.CompletedTask;
    }

    public async Task SectionInstructorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SectionInstructor? sectionInstructor = await _sectionInstructorRepository.GetAsync(
            predicate: si => si.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SectionInstructorShouldExistWhenSelected(sectionInstructor);
    }
}