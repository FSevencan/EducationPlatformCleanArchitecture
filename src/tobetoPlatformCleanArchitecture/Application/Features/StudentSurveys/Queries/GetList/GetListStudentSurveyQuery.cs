using Application.Features.StudentSurveys.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.StudentSurveys.Constants.StudentSurveysOperationClaims;

namespace Application.Features.StudentSurveys.Queries.GetList;

public class GetListStudentSurveyQuery : IRequest<GetListResponse<GetListStudentSurveyListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListStudentSurveys({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetStudentSurveys";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListStudentSurveyQueryHandler : IRequestHandler<GetListStudentSurveyQuery, GetListResponse<GetListStudentSurveyListItemDto>>
    {
        private readonly IStudentSurveyRepository _studentSurveyRepository;
        private readonly IMapper _mapper;

        public GetListStudentSurveyQueryHandler(IStudentSurveyRepository studentSurveyRepository, IMapper mapper)
        {
            _studentSurveyRepository = studentSurveyRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentSurveyListItemDto>> Handle(GetListStudentSurveyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentSurvey> studentSurveys = await _studentSurveyRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentSurveyListItemDto> response = _mapper.Map<GetListResponse<GetListStudentSurveyListItemDto>>(studentSurveys);
            return response;
        }
    }
}