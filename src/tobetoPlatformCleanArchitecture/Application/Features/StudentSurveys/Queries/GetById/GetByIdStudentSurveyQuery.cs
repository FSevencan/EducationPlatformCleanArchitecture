using Application.Features.StudentSurveys.Constants;
using Application.Features.StudentSurveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.StudentSurveys.Constants.StudentSurveysOperationClaims;

namespace Application.Features.StudentSurveys.Queries.GetById;

public class GetByIdStudentSurveyQuery : IRequest<GetByIdStudentSurveyResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdStudentSurveyQueryHandler : IRequestHandler<GetByIdStudentSurveyQuery, GetByIdStudentSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSurveyRepository _studentSurveyRepository;
        private readonly StudentSurveyBusinessRules _studentSurveyBusinessRules;

        public GetByIdStudentSurveyQueryHandler(IMapper mapper, IStudentSurveyRepository studentSurveyRepository, StudentSurveyBusinessRules studentSurveyBusinessRules)
        {
            _mapper = mapper;
            _studentSurveyRepository = studentSurveyRepository;
            _studentSurveyBusinessRules = studentSurveyBusinessRules;
        }

        public async Task<GetByIdStudentSurveyResponse> Handle(GetByIdStudentSurveyQuery request, CancellationToken cancellationToken)
        {
            StudentSurvey? studentSurvey = await _studentSurveyRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSurveyBusinessRules.StudentSurveyShouldExistWhenSelected(studentSurvey);

            GetByIdStudentSurveyResponse response = _mapper.Map<GetByIdStudentSurveyResponse>(studentSurvey);
            return response;
        }
    }
}