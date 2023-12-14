using Application.Features.ApplicationEducations.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ApplicationEducations;

public class ApplicationEducationsManager : IApplicationEducationsService
{
    private readonly IApplicationEducationRepository _applicationEducationRepository;
    private readonly ApplicationEducationBusinessRules _applicationEducationBusinessRules;

    public ApplicationEducationsManager(IApplicationEducationRepository applicationEducationRepository, ApplicationEducationBusinessRules applicationEducationBusinessRules)
    {
        _applicationEducationRepository = applicationEducationRepository;
        _applicationEducationBusinessRules = applicationEducationBusinessRules;
    }

    public async Task<ApplicationEducation?> GetAsync(
        Expression<Func<ApplicationEducation, bool>> predicate,
        Func<IQueryable<ApplicationEducation>, IIncludableQueryable<ApplicationEducation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ApplicationEducation? applicationEducation = await _applicationEducationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return applicationEducation;
    }

    public async Task<IPaginate<ApplicationEducation>?> GetListAsync(
        Expression<Func<ApplicationEducation, bool>>? predicate = null,
        Func<IQueryable<ApplicationEducation>, IOrderedQueryable<ApplicationEducation>>? orderBy = null,
        Func<IQueryable<ApplicationEducation>, IIncludableQueryable<ApplicationEducation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ApplicationEducation> applicationEducationList = await _applicationEducationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return applicationEducationList;
    }

    public async Task<ApplicationEducation> AddAsync(ApplicationEducation applicationEducation)
    {
        ApplicationEducation addedApplicationEducation = await _applicationEducationRepository.AddAsync(applicationEducation);

        return addedApplicationEducation;
    }

    public async Task<ApplicationEducation> UpdateAsync(ApplicationEducation applicationEducation)
    {
        ApplicationEducation updatedApplicationEducation = await _applicationEducationRepository.UpdateAsync(applicationEducation);

        return updatedApplicationEducation;
    }

    public async Task<ApplicationEducation> DeleteAsync(ApplicationEducation applicationEducation, bool permanent = false)
    {
        ApplicationEducation deletedApplicationEducation = await _applicationEducationRepository.DeleteAsync(applicationEducation);

        return deletedApplicationEducation;
    }
}
