using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserSections;

public interface IUserSectionsService
{
    Task<UserSection?> GetAsync(
        Expression<Func<UserSection, bool>> predicate,
        Func<IQueryable<UserSection>, IIncludableQueryable<UserSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserSection>?> GetListAsync(
        Expression<Func<UserSection, bool>>? predicate = null,
        Func<IQueryable<UserSection>, IOrderedQueryable<UserSection>>? orderBy = null,
        Func<IQueryable<UserSection>, IIncludableQueryable<UserSection, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserSection> AddAsync(UserSection userSection);
    Task<UserSection> UpdateAsync(UserSection userSection);
    Task<UserSection> DeleteAsync(UserSection userSection, bool permanent = false);
}
