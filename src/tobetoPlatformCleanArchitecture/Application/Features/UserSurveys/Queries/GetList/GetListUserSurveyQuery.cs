using Application.Features.UserSurveys.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserSurveys.Constants.UserSurveysOperationClaims;

namespace Application.Features.UserSurveys.Queries.GetList;

public class GetListUserSurveyQuery : IRequest<GetListResponse<GetListUserSurveyListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListUserSurveys({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetUserSurveys";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserSurveyQueryHandler : IRequestHandler<GetListUserSurveyQuery, GetListResponse<GetListUserSurveyListItemDto>>
    {
        private readonly IUserSurveyRepository _userSurveyRepository;
        private readonly IMapper _mapper;

        public GetListUserSurveyQueryHandler(IUserSurveyRepository userSurveyRepository, IMapper mapper)
        {
            _userSurveyRepository = userSurveyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserSurveyListItemDto>> Handle(GetListUserSurveyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserSurvey> userSurveys = await _userSurveyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserSurveyListItemDto> response = _mapper.Map<GetListResponse<GetListUserSurveyListItemDto>>(userSurveys);
            return response;
        }
    }
}