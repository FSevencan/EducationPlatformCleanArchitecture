using Application.Features.UserAnswers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserAnswers;

public class UserAnswersManager : IUserAnswersService
{
    private readonly IUserAnswerRepository _userAnswerRepository;
    private readonly UserAnswerBusinessRules _userAnswerBusinessRules;

    public UserAnswersManager(IUserAnswerRepository userAnswerRepository, UserAnswerBusinessRules userAnswerBusinessRules)
    {
        _userAnswerRepository = userAnswerRepository;
        _userAnswerBusinessRules = userAnswerBusinessRules;
    }

    public async Task<UserAnswer?> GetAsync(
        Expression<Func<UserAnswer, bool>> predicate,
        Func<IQueryable<UserAnswer>, IIncludableQueryable<UserAnswer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserAnswer? userAnswer = await _userAnswerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userAnswer;
    }

    public async Task<IPaginate<UserAnswer>?> GetListAsync(
        Expression<Func<UserAnswer, bool>>? predicate = null,
        Func<IQueryable<UserAnswer>, IOrderedQueryable<UserAnswer>>? orderBy = null,
        Func<IQueryable<UserAnswer>, IIncludableQueryable<UserAnswer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserAnswer> userAnswerList = await _userAnswerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userAnswerList;
    }

    public async Task<UserAnswer> AddAsync(UserAnswer userAnswer)
    {
        UserAnswer addedUserAnswer = await _userAnswerRepository.AddAsync(userAnswer);

        return addedUserAnswer;
    }

    public async Task<UserAnswer> UpdateAsync(UserAnswer userAnswer)
    {
        UserAnswer updatedUserAnswer = await _userAnswerRepository.UpdateAsync(userAnswer);

        return updatedUserAnswer;
    }

    public async Task<UserAnswer> DeleteAsync(UserAnswer userAnswer, bool permanent = false)
    {
        UserAnswer deletedUserAnswer = await _userAnswerRepository.DeleteAsync(userAnswer);

        return deletedUserAnswer;
    }
}
