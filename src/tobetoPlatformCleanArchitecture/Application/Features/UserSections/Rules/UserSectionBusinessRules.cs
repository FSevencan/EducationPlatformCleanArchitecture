using Application.Features.UserSections.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserSections.Rules;

public class UserSectionBusinessRules : BaseBusinessRules
{
    private readonly IUserSectionRepository _userSectionRepository;

    public UserSectionBusinessRules(IUserSectionRepository userSectionRepository)
    {
        _userSectionRepository = userSectionRepository;
    }

    public Task UserSectionShouldExistWhenSelected(UserSection? userSection)
    {
        if (userSection == null)
            throw new BusinessException(UserSectionsBusinessMessages.UserSectionNotExists);
        return Task.CompletedTask;
    }

    public async Task UserSectionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserSection? userSection = await _userSectionRepository.GetAsync(
            predicate: us => us.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserSectionShouldExistWhenSelected(userSection);
    }
}