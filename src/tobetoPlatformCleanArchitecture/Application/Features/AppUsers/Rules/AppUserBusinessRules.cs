using Application.Features.AppUsers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.AppUsers.Rules;

public class AppUserBusinessRules : BaseBusinessRules
{
    private readonly IAppUserRepository _appUserRepository;

    public AppUserBusinessRules(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public Task AppUserShouldExistWhenSelected(AppUser? appUser)
    {
        if (appUser == null)
            throw new BusinessException(AppUsersBusinessMessages.AppUserNotExists);
        return Task.CompletedTask;
    }

    public async Task AppUserIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AppUser? appUser = await _appUserRepository.GetAsync(
            predicate: au => au.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AppUserShouldExistWhenSelected(appUser);
    }
}