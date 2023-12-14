using Application.Features.UserSurveys.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserSurveys.Rules;

public class UserSurveyBusinessRules : BaseBusinessRules
{
    private readonly IUserSurveyRepository _userSurveyRepository;

    public UserSurveyBusinessRules(IUserSurveyRepository userSurveyRepository)
    {
        _userSurveyRepository = userSurveyRepository;
    }

    public Task UserSurveyShouldExistWhenSelected(UserSurvey? userSurvey)
    {
        if (userSurvey == null)
            throw new BusinessException(UserSurveysBusinessMessages.UserSurveyNotExists);
        return Task.CompletedTask;
    }

    public async Task UserSurveyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserSurvey? userSurvey = await _userSurveyRepository.GetAsync(
            predicate: us => us.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserSurveyShouldExistWhenSelected(userSurvey);
    }
}