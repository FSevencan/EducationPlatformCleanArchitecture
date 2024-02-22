using Application.Features.Districts.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Districts.Queries.GetAllDistrictsByProvince;

public class GetAllDistrictsByProvinceQuery : IRequest<GetListResponse<GetListDistrictListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public int provinceId { get; set; }

    public class GetAllDistrictsByProvinceQueryHandler : IRequestHandler<GetAllDistrictsByProvinceQuery, GetListResponse<GetListDistrictListItemDto>>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetAllDistrictsByProvinceQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDistrictListItemDto>> Handle(GetAllDistrictsByProvinceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<District> districts = await _districtRepository.GetListAsync(
                predicate: d=> d.ProvinceId == request.provinceId,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDistrictListItemDto> response = _mapper.Map<GetListResponse<GetListDistrictListItemDto>>(districts);
            return response;
        }
    }
}