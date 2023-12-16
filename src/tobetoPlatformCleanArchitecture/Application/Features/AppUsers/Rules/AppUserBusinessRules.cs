using Application.Features.AppUsers.Constants;
using Application.Features.Auth.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.Hashing;
using Domain.Entities;

namespace Application.Features.AppUsers.Rules;

public class AppUserBusinessRules : BaseBusinessRules
{
    private readonly IAppUserRepository _appUserRepository;

    public AppUserBusinessRules(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    public Task AppUserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            throw new BusinessException(AuthMessages.UserDontExists);
        return Task.CompletedTask;
    }

    public async Task AppUserIdShouldBeExistsWhenSelected(int id)
    {
        bool doesExist = await _appUserRepository.AnyAsync(predicate: u => u.Id == id, enableTracking: false);
        if (doesExist)
            throw new BusinessException(AuthMessages.UserDontExists);
    }

    public Task AppUserPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException(AuthMessages.PasswordDontMatch);
        return Task.CompletedTask;
    }

    public async Task AppUserEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _appUserRepository.AnyAsync(predicate: u => u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }

    public async Task AppUserEmailShouldNotExistsWhenUpdate(int id, string email)
    {
        bool doesExists = await _appUserRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email, enableTracking: false);
        if (doesExists)
            throw new BusinessException(AuthMessages.UserMailAlreadyExists);
    }

    internal Task AppUserShouldExistWhenSelected(AppUser? appUser) => throw new NotImplementedException();
}