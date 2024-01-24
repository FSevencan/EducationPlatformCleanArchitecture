using Application.Features.CampusEncounters.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.CampusEncounters.Constants.CampusEncountersOperationClaims;

namespace Application.Features.CampusEncounters.Queries.GetList;

public class GetListCampusEncounterQuery : IRequest<GetListResponse<GetListCampusEncounterListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCampusEncounters({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCampusEncounters";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCampusEncounterQueryHandler : IRequestHandler<GetListCampusEncounterQuery, GetListResponse<GetListCampusEncounterListItemDto>>
    {
        private readonly ICampusEncounterRepository _campusEncounterRepository;
        private readonly IMapper _mapper;

        public GetListCampusEncounterQueryHandler(ICampusEncounterRepository campusEncounterRepository, IMapper mapper)
        {
            _campusEncounterRepository = campusEncounterRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCampusEncounterListItemDto>> Handle(GetListCampusEncounterQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CampusEncounter> campusEncounters = await _campusEncounterRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCampusEncounterListItemDto> response = _mapper.Map<GetListResponse<GetListCampusEncounterListItemDto>>(campusEncounters);
            return response;
        }
    }
}