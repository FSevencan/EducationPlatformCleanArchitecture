using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Surveys.Queries.GetById;

public class GetByIdSurveyQuery : IRequest<GetByIdSurveyResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSurveyQueryHandler : IRequestHandler<GetByIdSurveyQuery, GetByIdSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public GetByIdSurveyQueryHandler(IMapper mapper, ISurveyRepository surveyRepository, SurveyBusinessRules surveyBusinessRules)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
        }

        public async Task<GetByIdSurveyResponse> Handle(GetByIdSurveyQuery request, CancellationToken cancellationToken)
        {
            Survey? survey = await _surveyRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyBusinessRules.SurveyShouldExistWhenSelected(survey);

            GetByIdSurveyResponse response = _mapper.Map<GetByIdSurveyResponse>(survey);
            return response;
        }
    }
}