using Application.Features.Sections.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Sections.Rules;

public class SectionBusinessRules : BaseBusinessRules
{
    private readonly ISectionRepository _sectionRepository;

    public SectionBusinessRules(ISectionRepository sectionRepository)
    {
        _sectionRepository = sectionRepository;
    }

    public Task SectionShouldExistWhenSelected(Section? section)
    {
        if (section == null)
            throw new BusinessException(SectionsBusinessMessages.SectionNotExists);
        return Task.CompletedTask;
    }

    public async Task SectionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Section? section = await _sectionRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SectionShouldExistWhenSelected(section);
    }
}