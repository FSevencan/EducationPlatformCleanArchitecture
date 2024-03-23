using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Choices;

public interface IChoicesService
{
    Task<Choice?> GetAsync(
        Expression<Func<Choice, bool>> predicate,
        Func<IQueryable<Choice>, IIncludableQueryable<Choice, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Choice>?> GetListAsync(
        Expression<Func<Choice, bool>>? predicate = null,
        Func<IQueryable<Choice>, IOrderedQueryable<Choice>>? orderBy = null,
        Func<IQueryable<Choice>, IIncludableQueryable<Choice, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Choice> AddAsync(Choice choice);
    Task<Choice> UpdateAsync(Choice choice);
    Task<Choice> DeleteAsync(Choice choice, bool permanent = false);
}
