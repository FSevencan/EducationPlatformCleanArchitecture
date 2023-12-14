using Application.Features.SectionAbouts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.SectionAbouts.Rules;

public class SectionAboutBusinessRules : BaseBusinessRules
{
    private readonly ISectionAboutRepository _sectionAboutRepository;

    public SectionAboutBusinessRules(ISectionAboutRepository sectionAboutRepository)
    {
        _sectionAboutRepository = sectionAboutRepository;
    }

    public Task SectionAboutShouldExistWhenSelected(SectionAbout? sectionAbout)
    {
        if (sectionAbout == null)
            throw new BusinessException(SectionAboutsBusinessMessages.SectionAboutNotExists);
        return Task.CompletedTask;
    }

    public async Task SectionAboutIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        SectionAbout? sectionAbout = await _sectionAboutRepository.GetAsync(
            predicate: sa => sa.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SectionAboutShouldExistWhenSelected(sectionAbout);
    }
}