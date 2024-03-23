using Application.Features.MentorshipSessions.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.MentorshipSessions.Constants.MentorshipSessionsOperationClaims;

namespace Application.Features.MentorshipSessions.Queries.GetList;

public class GetListMentorshipSessionQuery : IRequest<GetListResponse<GetListMentorshipSessionListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListMentorshipSessions({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetMentorshipSessions";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMentorshipSessionQueryHandler : IRequestHandler<GetListMentorshipSessionQuery, GetListResponse<GetListMentorshipSessionListItemDto>>
    {
        private readonly IMentorshipSessionRepository _mentorshipSessionRepository;
        private readonly IMapper _mapper;

        public GetListMentorshipSessionQueryHandler(IMentorshipSessionRepository mentorshipSessionRepository, IMapper mapper)
        {
            _mentorshipSessionRepository = mentorshipSessionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMentorshipSessionListItemDto>> Handle(GetListMentorshipSessionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<MentorshipSession> mentorshipSessions = await _mentorshipSessionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListMentorshipSessionListItemDto> response = _mapper.Map<GetListResponse<GetListMentorshipSessionListItemDto>>(mentorshipSessions);
            return response;
        }
    }
}