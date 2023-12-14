using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Languages;

public class LanguagesManager : ILanguagesService
{
    private readonly ILanguageRepository _languageRepository;
    private readonly LanguageBusinessRules _languageBusinessRules;

    public LanguagesManager(ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
    {
        _languageRepository = languageRepository;
        _languageBusinessRules = languageBusinessRules;
    }

    public async Task<Language?> GetAsync(
        Expression<Func<Language, bool>> predicate,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Language? language = await _languageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return language;
    }

    public async Task<IPaginate<Language>?> GetListAsync(
        Expression<Func<Language, bool>>? predicate = null,
        Func<IQueryable<Language>, IOrderedQueryable<Language>>? orderBy = null,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Language> languageList = await _languageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return languageList;
    }

    public async Task<Language> AddAsync(Language language)
    {
        Language addedLanguage = await _languageRepository.AddAsync(language);

        return addedLanguage;
    }

    public async Task<Language> UpdateAsync(Language language)
    {
        Language updatedLanguage = await _languageRepository.UpdateAsync(language);

        return updatedLanguage;
    }

    public async Task<Language> DeleteAsync(Language language, bool permanent = false)
    {
        Language deletedLanguage = await _languageRepository.DeleteAsync(language);

        return deletedLanguage;
    }
}
