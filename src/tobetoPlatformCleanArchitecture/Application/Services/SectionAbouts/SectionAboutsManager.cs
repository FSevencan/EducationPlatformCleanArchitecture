using Application.Features.SectionAbouts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SectionAbouts;

public class SectionAboutsManager : ISectionAboutsService
{
    private readonly ISectionAboutRepository _sectionAboutRepository;
    private readonly SectionAboutBusinessRules _sectionAboutBusinessRules;

    public SectionAboutsManager(ISectionAboutRepository sectionAboutRepository, SectionAboutBusinessRules sectionAboutBusinessRules)
    {
        _sectionAboutRepository = sectionAboutRepository;
        _sectionAboutBusinessRules = sectionAboutBusinessRules;
    }

    public async Task<SectionAbout?> GetAsync(
        Expression<Func<SectionAbout, bool>> predicate,
        Func<IQueryable<SectionAbout>, IIncludableQueryable<SectionAbout, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SectionAbout? sectionAbout = await _sectionAboutRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sectionAbout;
    }

    public async Task<IPaginate<SectionAbout>?> GetListAsync(
        Expression<Func<SectionAbout, bool>>? predicate = null,
        Func<IQueryable<SectionAbout>, IOrderedQueryable<SectionAbout>>? orderBy = null,
        Func<IQueryable<SectionAbout>, IIncludableQueryable<SectionAbout, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SectionAbout> sectionAboutList = await _sectionAboutRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sectionAboutList;
    }

    public async Task<SectionAbout> AddAsync(SectionAbout sectionAbout)
    {
        SectionAbout addedSectionAbout = await _sectionAboutRepository.AddAsync(sectionAbout);

        return addedSectionAbout;
    }

    public async Task<SectionAbout> UpdateAsync(SectionAbout sectionAbout)
    {
        SectionAbout updatedSectionAbout = await _sectionAboutRepository.UpdateAsync(sectionAbout);

        return updatedSectionAbout;
    }

    public async Task<SectionAbout> DeleteAsync(SectionAbout sectionAbout, bool permanent = false)
    {
        SectionAbout deletedSectionAbout = await _sectionAboutRepository.DeleteAsync(sectionAbout);

        return deletedSectionAbout;
    }
}
