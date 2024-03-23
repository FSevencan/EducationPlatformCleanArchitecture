using Application.Features.Choices.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Choices.Constants.ChoicesOperationClaims;

namespace Application.Features.Choices.Queries.GetList;

public class GetListChoiceQuery : IRequest<GetListResponse<GetListChoiceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListChoices({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetChoices";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListChoiceQueryHandler : IRequestHandler<GetListChoiceQuery, GetListResponse<GetListChoiceListItemDto>>
    {
        private readonly IChoiceRepository _choiceRepository;
        private readonly IMapper _mapper;

        public GetListChoiceQueryHandler(IChoiceRepository choiceRepository, IMapper mapper)
        {
            _choiceRepository = choiceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListChoiceListItemDto>> Handle(GetListChoiceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Choice> choices = await _choiceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListChoiceListItemDto> response = _mapper.Map<GetListResponse<GetListChoiceListItemDto>>(choices);
            return response;
        }
    }
}