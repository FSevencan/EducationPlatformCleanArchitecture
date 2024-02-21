using Application.Features.Provinces.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Provinces.Rules;

public class ProvinceBusinessRules : BaseBusinessRules
{
    private readonly IProvinceRepository _provinceRepository;

    public ProvinceBusinessRules(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public Task ProvinceShouldExistWhenSelected(Province? province)
    {
        if (province == null)
            throw new BusinessException(ProvincesBusinessMessages.ProvinceNotExists);
        return Task.CompletedTask;
    }

    public async Task ProvinceIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Province? province = await _provinceRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProvinceShouldExistWhenSelected(province);
    }
}