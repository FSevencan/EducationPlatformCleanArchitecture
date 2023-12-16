using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AppUsers;

public interface IAppUsersService
{
    Task<AppUser?> GetAsync(
        Expression<Func<AppUser, bool>> predicate,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AppUser>?> GetListAsync(
        Expression<Func<AppUser, bool>>? predicate = null,
        Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>>? orderBy = null,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AppUser> AddAsync(AppUser appUser);
    Task<AppUser> UpdateAsync(AppUser appUser);
    Task<AppUser> DeleteAsync(AppUser appUser, bool permanent = false);
}
