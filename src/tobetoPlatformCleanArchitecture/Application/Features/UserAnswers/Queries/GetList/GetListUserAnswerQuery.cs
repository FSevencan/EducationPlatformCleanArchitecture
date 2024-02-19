using Application.Features.UserAnswers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserAnswers.Constants.UserAnswersOperationClaims;

namespace Application.Features.UserAnswers.Queries.GetList;

public class GetListUserAnswerQuery : IRequest<GetListResponse<GetListUserAnswerListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListUserAnswers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetUserAnswers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserAnswerQueryHandler : IRequestHandler<GetListUserAnswerQuery, GetListResponse<GetListUserAnswerListItemDto>>
    {
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IMapper _mapper;

        public GetListUserAnswerQueryHandler(IUserAnswerRepository userAnswerRepository, IMapper mapper)
        {
            _userAnswerRepository = userAnswerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserAnswerListItemDto>> Handle(GetListUserAnswerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserAnswer> userAnswers = await _userAnswerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserAnswerListItemDto> response = _mapper.Map<GetListResponse<GetListUserAnswerListItemDto>>(userAnswers);
            return response;
        }
    }
}