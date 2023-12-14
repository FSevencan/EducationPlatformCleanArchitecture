using Application.Features.ApplicationEducations.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ApplicationEducations.Rules;

public class ApplicationEducationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationEducationRepository _applicationEducationRepository;

    public ApplicationEducationBusinessRules(IApplicationEducationRepository applicationEducationRepository)
    {
        _applicationEducationRepository = applicationEducationRepository;
    }

    public Task ApplicationEducationShouldExistWhenSelected(ApplicationEducation? applicationEducation)
    {
        if (applicationEducation == null)
            throw new BusinessException(ApplicationEducationsBusinessMessages.ApplicationEducationNotExists);
        return Task.CompletedTask;
    }

    public async Task ApplicationEducationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ApplicationEducation? applicationEducation = await _applicationEducationRepository.GetAsync(
            predicate: ae => ae.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ApplicationEducationShouldExistWhenSelected(applicationEducation);
    }
}