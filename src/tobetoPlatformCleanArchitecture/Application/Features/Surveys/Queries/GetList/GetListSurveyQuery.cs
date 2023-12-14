using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Surveys.Queries.GetList;

public class GetListSurveyQuery : IRequest<GetListResponse<GetListSurveyListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSurveyQueryHandler : IRequestHandler<GetListSurveyQuery, GetListResponse<GetListSurveyListItemDto>>
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public GetListSurveyQueryHandler(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSurveyListItemDto>> Handle(GetListSurveyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Survey> surveys = await _surveyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSurveyListItemDto> response = _mapper.Map<GetListResponse<GetListSurveyListItemDto>>(surveys);
            return response;
        }
    }
}