using Application.Features.SectionAbouts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.SectionAbouts.Constants.SectionAboutsOperationClaims;

namespace Application.Features.SectionAbouts.Queries.GetList;

public class GetListSectionAboutQuery : IRequest<GetListResponse<GetListSectionAboutListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListSectionAbouts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetSectionAbouts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListSectionAboutQueryHandler : IRequestHandler<GetListSectionAboutQuery, GetListResponse<GetListSectionAboutListItemDto>>
    {
        private readonly ISectionAboutRepository _sectionAboutRepository;
        private readonly IMapper _mapper;

        public GetListSectionAboutQueryHandler(ISectionAboutRepository sectionAboutRepository, IMapper mapper)
        {
            _sectionAboutRepository = sectionAboutRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSectionAboutListItemDto>> Handle(GetListSectionAboutQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SectionAbout> sectionAbouts = await _sectionAboutRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSectionAboutListItemDto> response = _mapper.Map<GetListResponse<GetListSectionAboutListItemDto>>(sectionAbouts);
            return response;
        }
    }
}