using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Likes;

public interface ILikesService
{
    Task<Like?> GetAsync(
        Expression<Func<Like, bool>> predicate,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Like>?> GetListAsync(
        Expression<Func<Like, bool>>? predicate = null,
        Func<IQueryable<Like>, IOrderedQueryable<Like>>? orderBy = null,
        Func<IQueryable<Like>, IIncludableQueryable<Like, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Like> AddAsync(Like like);
    Task<Like> UpdateAsync(Like like);
    Task<Like> DeleteAsync(Like like, bool permanent = false);
}
