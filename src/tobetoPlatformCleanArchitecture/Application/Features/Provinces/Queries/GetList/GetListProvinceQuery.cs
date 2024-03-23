using Application.Features.Provinces.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Provinces.Constants.ProvincesOperationClaims;

namespace Application.Features.Provinces.Queries.GetList;

public class GetListProvinceQuery : IRequest<GetListResponse<GetListProvinceListItemDto>>
{
    public PageRequest PageRequest { get; set; }


    public class GetListProvinceQueryHandler : IRequestHandler<GetListProvinceQuery, GetListResponse<GetListProvinceListItemDto>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public GetListProvinceQueryHandler(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProvinceListItemDto>> Handle(GetListProvinceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Province> provinces = await _provinceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProvinceListItemDto> response = _mapper.Map<GetListResponse<GetListProvinceListItemDto>>(provinces);
            return response;
        }
    }
}