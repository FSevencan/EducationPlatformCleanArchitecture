using Application.Features.Languages.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Languages.Constants.LanguagesOperationClaims;

namespace Application.Features.Languages.Queries.GetList;

public class GetListLanguageQuery : IRequest<GetListResponse<GetListLanguageListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListLanguages({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetLanguages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, GetListResponse<GetListLanguageListItemDto>>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLanguageListItemDto>> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> languages = await _languageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListLanguageListItemDto>>(languages);
            return response;
        }
    }
}