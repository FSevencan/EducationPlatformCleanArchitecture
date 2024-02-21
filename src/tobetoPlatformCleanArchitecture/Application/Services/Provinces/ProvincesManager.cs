using Application.Features.Provinces.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Provinces;

public class ProvincesManager : IProvincesService
{
    private readonly IProvinceRepository _provinceRepository;
    private readonly ProvinceBusinessRules _provinceBusinessRules;

    public ProvincesManager(IProvinceRepository provinceRepository, ProvinceBusinessRules provinceBusinessRules)
    {
        _provinceRepository = provinceRepository;
        _provinceBusinessRules = provinceBusinessRules;
    }

    public async Task<Province?> GetAsync(
        Expression<Func<Province, bool>> predicate,
        Func<IQueryable<Province>, IIncludableQueryable<Province, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Province? province = await _provinceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return province;
    }

    public async Task<IPaginate<Province>?> GetListAsync(
        Expression<Func<Province, bool>>? predicate = null,
        Func<IQueryable<Province>, IOrderedQueryable<Province>>? orderBy = null,
        Func<IQueryable<Province>, IIncludableQueryable<Province, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Province> provinceList = await _provinceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return provinceList;
    }

    public async Task<Province> AddAsync(Province province)
    {
        Province addedProvince = await _provinceRepository.AddAsync(province);

        return addedProvince;
    }

    public async Task<Province> UpdateAsync(Province province)
    {
        Province updatedProvince = await _provinceRepository.UpdateAsync(province);

        return updatedProvince;
    }

    public async Task<Province> DeleteAsync(Province province, bool permanent = false)
    {
        Province deletedProvince = await _provinceRepository.DeleteAsync(province);

        return deletedProvince;
    }
}
