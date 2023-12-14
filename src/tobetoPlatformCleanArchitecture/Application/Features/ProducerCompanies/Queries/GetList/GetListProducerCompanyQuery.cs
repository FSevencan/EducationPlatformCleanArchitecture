using Application.Features.ProducerCompanies.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProducerCompanies.Constants.ProducerCompaniesOperationClaims;

namespace Application.Features.ProducerCompanies.Queries.GetList;

public class GetListProducerCompanyQuery : IRequest<GetListResponse<GetListProducerCompanyListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListProducerCompanies({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetProducerCompanies";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProducerCompanyQueryHandler : IRequestHandler<GetListProducerCompanyQuery, GetListResponse<GetListProducerCompanyListItemDto>>
    {
        private readonly IProducerCompanyRepository _producerCompanyRepository;
        private readonly IMapper _mapper;

        public GetListProducerCompanyQueryHandler(IProducerCompanyRepository producerCompanyRepository, IMapper mapper)
        {
            _producerCompanyRepository = producerCompanyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProducerCompanyListItemDto>> Handle(GetListProducerCompanyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProducerCompany> producerCompanies = await _producerCompanyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProducerCompanyListItemDto> response = _mapper.Map<GetListResponse<GetListProducerCompanyListItemDto>>(producerCompanies);
            return response;
        }
    }
}