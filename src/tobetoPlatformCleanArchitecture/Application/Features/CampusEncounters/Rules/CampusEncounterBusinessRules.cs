using Application.Features.CampusEncounters.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CampusEncounters.Rules;

public class CampusEncounterBusinessRules : BaseBusinessRules
{
    private readonly ICampusEncounterRepository _campusEncounterRepository;

    public CampusEncounterBusinessRules(ICampusEncounterRepository campusEncounterRepository)
    {
        _campusEncounterRepository = campusEncounterRepository;
    }

    public Task CampusEncounterShouldExistWhenSelected(CampusEncounter? campusEncounter)
    {
        if (campusEncounter == null)
            throw new BusinessException(CampusEncountersBusinessMessages.CampusEncounterNotExists);
        return Task.CompletedTask;
    }

    public async Task CampusEncounterIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CampusEncounter? campusEncounter = await _campusEncounterRepository.GetAsync(
            predicate: ce => ce.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CampusEncounterShouldExistWhenSelected(campusEncounter);
    }
}