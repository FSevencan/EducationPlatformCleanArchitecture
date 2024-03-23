using Application.Features.Provinces.Constants;
using Application.Features.Provinces.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Provinces.Constants.ProvincesOperationClaims;

namespace Application.Features.Provinces.Queries.GetById;

public class GetByIdProvinceQuery : IRequest<GetByIdProvinceResponse>
{
    public int Id { get; set; }


    public class GetByIdProvinceQueryHandler : IRequestHandler<GetByIdProvinceQuery, GetByIdProvinceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ProvinceBusinessRules _provinceBusinessRules;

        public GetByIdProvinceQueryHandler(IMapper mapper, IProvinceRepository provinceRepository, ProvinceBusinessRules provinceBusinessRules)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
            _provinceBusinessRules = provinceBusinessRules;
        }

        public async Task<GetByIdProvinceResponse> Handle(GetByIdProvinceQuery request, CancellationToken cancellationToken)
        {
            Province? province = await _provinceRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _provinceBusinessRules.ProvinceShouldExistWhenSelected(province);

            GetByIdProvinceResponse response = _mapper.Map<GetByIdProvinceResponse>(province);
            return response;
        }
    }
}