using Application.Features.AppUsers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AppUsers;

public class AppUsersManager : IAppUsersService
{
    private readonly IAppUserRepository _appUserRepository;
    private readonly AppUserBusinessRules _appUserBusinessRules;

    public AppUsersManager(IAppUserRepository appUserRepository, AppUserBusinessRules appUserBusinessRules)
    {
        _appUserRepository = appUserRepository;
        _appUserBusinessRules = appUserBusinessRules;
    }

    public async Task<AppUser?> GetAsync(
        Expression<Func<AppUser, bool>> predicate,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AppUser? appUser = await _appUserRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return appUser;
    }

    public async Task<IPaginate<AppUser>?> GetListAsync(
        Expression<Func<AppUser, bool>>? predicate = null,
        Func<IQueryable<AppUser>, IOrderedQueryable<AppUser>>? orderBy = null,
        Func<IQueryable<AppUser>, IIncludableQueryable<AppUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AppUser> appUserList = await _appUserRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return appUserList;
    }

    public async Task<AppUser> AddAsync(AppUser appUser)
    {
        AppUser addedAppUser = await _appUserRepository.AddAsync(appUser);

        return addedAppUser;
    }

    public async Task<AppUser> UpdateAsync(AppUser appUser)
    {
        AppUser updatedAppUser = await _appUserRepository.UpdateAsync(appUser);

        return updatedAppUser;
    }

    public async Task<AppUser> DeleteAsync(AppUser appUser, bool permanent = false)
    {
        AppUser deletedAppUser = await _appUserRepository.DeleteAsync(appUser);

        return deletedAppUser;
    }
}
