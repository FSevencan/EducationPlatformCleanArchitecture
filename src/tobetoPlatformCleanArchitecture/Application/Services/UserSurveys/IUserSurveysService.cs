using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserSurveys;

public interface IUserSurveysService
{
    Task<UserSurvey?> GetAsync(
        Expression<Func<UserSurvey, bool>> predicate,
        Func<IQueryable<UserSurvey>, IIncludableQueryable<UserSurvey, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserSurvey>?> GetListAsync(
        Expression<Func<UserSurvey, bool>>? predicate = null,
        Func<IQueryable<UserSurvey>, IOrderedQueryable<UserSurvey>>? orderBy = null,
        Func<IQueryable<UserSurvey>, IIncludableQueryable<UserSurvey, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserSurvey> AddAsync(UserSurvey userSurvey);
    Task<UserSurvey> UpdateAsync(UserSurvey userSurvey);
    Task<UserSurvey> DeleteAsync(UserSurvey userSurvey, bool permanent = false);
}
