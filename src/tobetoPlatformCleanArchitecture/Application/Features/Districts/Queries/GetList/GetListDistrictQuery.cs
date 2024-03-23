using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Districts.Queries.GetList;

public class GetListDistrictQuery : IRequest<GetListResponse<GetListDistrictListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDistrictQueryHandler : IRequestHandler<GetListDistrictQuery, GetListResponse<GetListDistrictListItemDto>>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public GetListDistrictQueryHandler(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDistrictListItemDto>> Handle(GetListDistrictQuery request, CancellationToken cancellationToken)
        {
            IPaginate<District> districts = await _districtRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDistrictListItemDto> response = _mapper.Map<GetListResponse<GetListDistrictListItemDto>>(districts);
            return response;
        }
    }
}