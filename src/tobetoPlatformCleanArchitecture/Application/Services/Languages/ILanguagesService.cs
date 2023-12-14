using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Languages;

public interface ILanguagesService
{
    Task<Language?> GetAsync(
        Expression<Func<Language, bool>> predicate,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Language>?> GetListAsync(
        Expression<Func<Language, bool>>? predicate = null,
        Func<IQueryable<Language>, IOrderedQueryable<Language>>? orderBy = null,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Language> AddAsync(Language language);
    Task<Language> UpdateAsync(Language language);
    Task<Language> DeleteAsync(Language language, bool permanent = false);
}
