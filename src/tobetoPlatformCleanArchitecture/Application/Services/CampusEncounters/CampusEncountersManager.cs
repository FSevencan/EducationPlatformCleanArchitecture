using Application.Features.CampusEncounters.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CampusEncounters;

public class CampusEncountersManager : ICampusEncountersService
{
    private readonly ICampusEncounterRepository _campusEncounterRepository;
    private readonly CampusEncounterBusinessRules _campusEncounterBusinessRules;

    public CampusEncountersManager(ICampusEncounterRepository campusEncounterRepository, CampusEncounterBusinessRules campusEncounterBusinessRules)
    {
        _campusEncounterRepository = campusEncounterRepository;
        _campusEncounterBusinessRules = campusEncounterBusinessRules;
    }

    public async Task<CampusEncounter?> GetAsync(
        Expression<Func<CampusEncounter, bool>> predicate,
        Func<IQueryable<CampusEncounter>, IIncludableQueryable<CampusEncounter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CampusEncounter? campusEncounter = await _campusEncounterRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return campusEncounter;
    }

    public async Task<IPaginate<CampusEncounter>?> GetListAsync(
        Expression<Func<CampusEncounter, bool>>? predicate = null,
        Func<IQueryable<CampusEncounter>, IOrderedQueryable<CampusEncounter>>? orderBy = null,
        Func<IQueryable<CampusEncounter>, IIncludableQueryable<CampusEncounter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CampusEncounter> campusEncounterList = await _campusEncounterRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return campusEncounterList;
    }

    public async Task<CampusEncounter> AddAsync(CampusEncounter campusEncounter)
    {
        CampusEncounter addedCampusEncounter = await _campusEncounterRepository.AddAsync(campusEncounter);

        return addedCampusEncounter;
    }

    public async Task<CampusEncounter> UpdateAsync(CampusEncounter campusEncounter)
    {
        CampusEncounter updatedCampusEncounter = await _campusEncounterRepository.UpdateAsync(campusEncounter);

        return updatedCampusEncounter;
    }

    public async Task<CampusEncounter> DeleteAsync(CampusEncounter campusEncounter, bool permanent = false)
    {
        CampusEncounter deletedCampusEncounter = await _campusEncounterRepository.DeleteAsync(campusEncounter);

        return deletedCampusEncounter;
    }
}
