using Application.Features.Sections.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sections;

public class SectionsManager : ISectionsService
{
    private readonly ISectionRepository _sectionRepository;
    private readonly SectionBusinessRules _sectionBusinessRules;

    public SectionsManager(ISectionRepository sectionRepository, SectionBusinessRules sectionBusinessRules)
    {
        _sectionRepository = sectionRepository;
        _sectionBusinessRules = sectionBusinessRules;
    }

    public async Task<Section?> GetAsync(
        Expression<Func<Section, bool>> predicate,
        Func<IQueryable<Section>, IIncludableQueryable<Section, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Section? section = await _sectionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return section;
    }

    public async Task<IPaginate<Section>?> GetListAsync(
        Expression<Func<Section, bool>>? predicate = null,
        Func<IQueryable<Section>, IOrderedQueryable<Section>>? orderBy = null,
        Func<IQueryable<Section>, IIncludableQueryable<Section, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Section> sectionList = await _sectionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sectionList;
    }

    public async Task<Section> AddAsync(Section section)
    {
        Section addedSection = await _sectionRepository.AddAsync(section);

        return addedSection;
    }

    public async Task<Section> UpdateAsync(Section section)
    {
        Section updatedSection = await _sectionRepository.UpdateAsync(section);

        return updatedSection;
    }

    public async Task<Section> DeleteAsync(Section section, bool permanent = false)
    {
        Section deletedSection = await _sectionRepository.DeleteAsync(section);

        return deletedSection;
    }
}
