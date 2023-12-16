using Application.Features.AppUsers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.AppUsers.Constants.AppUsersOperationClaims;

namespace Application.Features.AppUsers.Queries.GetList;

public class GetListAppUserQuery : IRequest<GetListResponse<GetListAppUserListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListAppUsers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetAppUsers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAppUserQueryHandler : IRequestHandler<GetListAppUserQuery, GetListResponse<GetListAppUserListItemDto>>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public GetListAppUserQueryHandler(IAppUserRepository appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAppUserListItemDto>> Handle(GetListAppUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AppUser> appUsers = await _appUserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAppUserListItemDto> response = _mapper.Map<GetListResponse<GetListAppUserListItemDto>>(appUsers);
            return response;
        }
    }
}