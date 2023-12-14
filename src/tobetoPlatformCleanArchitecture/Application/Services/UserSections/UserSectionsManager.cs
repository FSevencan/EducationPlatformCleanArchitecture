using Application.Features.UserSections.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserSections;

public class UserSectionsManager : IUserSectionsService
{
    private readonly IUserSectionRepository _userSectionRepository;
    private readonly UserSectionBusinessRules _userSectionBusinessRules;

    public UserSectionsManager(IUserSectionRepository userSectionRepository, UserSectionBusinessRules userSectionBusinessRules)
    {
        _userSectionRepository = userSectionRepository;
        _userSectionBusinessRules = userSectionBusinessRules;
    }

    public async Task<UserSection?> GetAsync(
        Expression<Func<UserSection, bool>> predicate,
        Func<IQueryable<UserSection>, IIncludableQueryable<UserSection, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserSection? userSection = await _userSectionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userSection;
    }

    public async Task<IPaginate<UserSection>?> GetListAsync(
        Expression<Func<UserSection, bool>>? predicate = null,
        Func<IQueryable<UserSection>, IOrderedQueryable<UserSection>>? orderBy = null,
        Func<IQueryable<UserSection>, IIncludableQueryable<UserSection, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserSection> userSectionList = await _userSectionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userSectionList;
    }

    public async Task<UserSection> AddAsync(UserSection userSection)
    {
        UserSection addedUserSection = await _userSectionRepository.AddAsync(userSection);

        return addedUserSection;
    }

    public async Task<UserSection> UpdateAsync(UserSection userSection)
    {
        UserSection updatedUserSection = await _userSectionRepository.UpdateAsync(userSection);

        return updatedUserSection;
    }

    public async Task<UserSection> DeleteAsync(UserSection userSection, bool permanent = false)
    {
        UserSection deletedUserSection = await _userSectionRepository.DeleteAsync(userSection);

        return deletedUserSection;
    }
}
