using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Subscriptions;

public interface ISubscriptionsService
{
    Task<Subscription?> GetAsync(
        Expression<Func<Subscription, bool>> predicate,
        Func<IQueryable<Subscription>, IIncludableQueryable<Subscription, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Subscription>?> GetListAsync(
        Expression<Func<Subscription, bool>>? predicate = null,
        Func<IQueryable<Subscription>, IOrderedQueryable<Subscription>>? orderBy = null,
        Func<IQueryable<Subscription>, IIncludableQueryable<Subscription, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Subscription> AddAsync(Subscription subscription);
    Task<Subscription> UpdateAsync(Subscription subscription);
    Task<Subscription> DeleteAsync(Subscription subscription, bool permanent = false);
}
