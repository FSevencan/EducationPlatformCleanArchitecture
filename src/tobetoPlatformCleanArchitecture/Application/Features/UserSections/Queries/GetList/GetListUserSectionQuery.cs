using Application.Features.UserSections.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserSections.Constants.UserSectionsOperationClaims;

namespace Application.Features.UserSections.Queries.GetList;

public class GetListUserSectionQuery : IRequest<GetListResponse<GetListUserSectionListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListUserSections({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetUserSections";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserSectionQueryHandler : IRequestHandler<GetListUserSectionQuery, GetListResponse<GetListUserSectionListItemDto>>
    {
        private readonly IUserSectionRepository _userSectionRepository;
        private readonly IMapper _mapper;

        public GetListUserSectionQueryHandler(IUserSectionRepository userSectionRepository, IMapper mapper)
        {
            _userSectionRepository = userSectionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserSectionListItemDto>> Handle(GetListUserSectionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserSection> userSections = await _userSectionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserSectionListItemDto> response = _mapper.Map<GetListResponse<GetListUserSectionListItemDto>>(userSections);
            return response;
        }
    }
}