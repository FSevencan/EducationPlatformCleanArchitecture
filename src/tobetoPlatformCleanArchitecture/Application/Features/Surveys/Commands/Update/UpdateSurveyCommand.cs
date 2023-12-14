using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Surveys.Commands.Update;

public class UpdateSurveyCommand : IRequest<UpdatedSurveyResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }

    public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, UpdatedSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public UpdateSurveyCommandHandler(IMapper mapper, ISurveyRepository surveyRepository,
                                         SurveyBusinessRules surveyBusinessRules)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
        }

        public async Task<UpdatedSurveyResponse> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            Survey? survey = await _surveyRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _surveyBusinessRules.SurveyShouldExistWhenSelected(survey);
            survey = _mapper.Map(request, survey);

            await _surveyRepository.UpdateAsync(survey!);

            UpdatedSurveyResponse response = _mapper.Map<UpdatedSurveyResponse>(survey);
            return response;
        }
    }
}