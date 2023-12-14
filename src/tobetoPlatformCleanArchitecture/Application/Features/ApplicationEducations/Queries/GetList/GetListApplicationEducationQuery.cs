using Application.Features.ApplicationEducations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ApplicationEducations.Constants.ApplicationEducationsOperationClaims;

namespace Application.Features.ApplicationEducations.Queries.GetList;

public class GetListApplicationEducationQuery : IRequest<GetListResponse<GetListApplicationEducationListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListApplicationEducations({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetApplicationEducations";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListApplicationEducationQueryHandler : IRequestHandler<GetListApplicationEducationQuery, GetListResponse<GetListApplicationEducationListItemDto>>
    {
        private readonly IApplicationEducationRepository _applicationEducationRepository;
        private readonly IMapper _mapper;

        public GetListApplicationEducationQueryHandler(IApplicationEducationRepository applicationEducationRepository, IMapper mapper)
        {
            _applicationEducationRepository = applicationEducationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListApplicationEducationListItemDto>> Handle(GetListApplicationEducationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ApplicationEducation> applicationEducations = await _applicationEducationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListApplicationEducationListItemDto> response = _mapper.Map<GetListResponse<GetListApplicationEducationListItemDto>>(applicationEducations);
            return response;
        }
    }
}