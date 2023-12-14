using Application.Features.UserSurveys.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserSurveys;

public class UserSurveysManager : IUserSurveysService
{
    private readonly IUserSurveyRepository _userSurveyRepository;
    private readonly UserSurveyBusinessRules _userSurveyBusinessRules;

    public UserSurveysManager(IUserSurveyRepository userSurveyRepository, UserSurveyBusinessRules userSurveyBusinessRules)
    {
        _userSurveyRepository = userSurveyRepository;
        _userSurveyBusinessRules = userSurveyBusinessRules;
    }

    public async Task<UserSurvey?> GetAsync(
        Expression<Func<UserSurvey, bool>> predicate,
        Func<IQueryable<UserSurvey>, IIncludableQueryable<UserSurvey, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserSurvey? userSurvey = await _userSurveyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userSurvey;
    }

    public async Task<IPaginate<UserSurvey>?> GetListAsync(
        Expression<Func<UserSurvey, bool>>? predicate = null,
        Func<IQueryable<UserSurvey>, IOrderedQueryable<UserSurvey>>? orderBy = null,
        Func<IQueryable<UserSurvey>, IIncludableQueryable<UserSurvey, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserSurvey> userSurveyList = await _userSurveyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userSurveyList;
    }

    public async Task<UserSurvey> AddAsync(UserSurvey userSurvey)
    {
        UserSurvey addedUserSurvey = await _userSurveyRepository.AddAsync(userSurvey);

        return addedUserSurvey;
    }

    public async Task<UserSurvey> UpdateAsync(UserSurvey userSurvey)
    {
        UserSurvey updatedUserSurvey = await _userSurveyRepository.UpdateAsync(userSurvey);

        return updatedUserSurvey;
    }

    public async Task<UserSurvey> DeleteAsync(UserSurvey userSurvey, bool permanent = false)
    {
        UserSurvey deletedUserSurvey = await _userSurveyRepository.DeleteAsync(userSurvey);

        return deletedUserSurvey;
    }
}
