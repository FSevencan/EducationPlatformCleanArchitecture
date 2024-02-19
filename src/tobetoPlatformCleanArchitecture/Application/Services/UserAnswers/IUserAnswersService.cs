using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserAnswers;

public interface IUserAnswersService
{
    Task<UserAnswer?> GetAsync(
        Expression<Func<UserAnswer, bool>> predicate,
        Func<IQueryable<UserAnswer>, IIncludableQueryable<UserAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserAnswer>?> GetListAsync(
        Expression<Func<UserAnswer, bool>>? predicate = null,
        Func<IQueryable<UserAnswer>, IOrderedQueryable<UserAnswer>>? orderBy = null,
        Func<IQueryable<UserAnswer>, IIncludableQueryable<UserAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserAnswer> AddAsync(UserAnswer userAnswer);
    Task<UserAnswer> UpdateAsync(UserAnswer userAnswer);
    Task<UserAnswer> DeleteAsync(UserAnswer userAnswer, bool permanent = false);
}
