using Application.Features.StudentSurveys.Constants;
using Application.Features.StudentSurveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.StudentSurveys.Constants.StudentSurveysOperationClaims;

namespace Application.Features.StudentSurveys.Commands.Update;

public class UpdateStudentSurveyCommand : IRequest<UpdatedStudentSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int StudentId { get; set; }
    public Guid SurveyId { get; set; }
    public Student Student { get; set; }
    public Survey Survey { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSurveysOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSurveys";

    public class UpdateStudentSurveyCommandHandler : IRequestHandler<UpdateStudentSurveyCommand, UpdatedStudentSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSurveyRepository _studentSurveyRepository;
        private readonly StudentSurveyBusinessRules _studentSurveyBusinessRules;

        public UpdateStudentSurveyCommandHandler(IMapper mapper, IStudentSurveyRepository studentSurveyRepository,
                                         StudentSurveyBusinessRules studentSurveyBusinessRules)
        {
            _mapper = mapper;
            _studentSurveyRepository = studentSurveyRepository;
            _studentSurveyBusinessRules = studentSurveyBusinessRules;
        }

        public async Task<UpdatedStudentSurveyResponse> Handle(UpdateStudentSurveyCommand request, CancellationToken cancellationToken)
        {
            StudentSurvey? studentSurvey = await _studentSurveyRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSurveyBusinessRules.StudentSurveyShouldExistWhenSelected(studentSurvey);
            studentSurvey = _mapper.Map(request, studentSurvey);

            await _studentSurveyRepository.UpdateAsync(studentSurvey!);

            UpdatedStudentSurveyResponse response = _mapper.Map<UpdatedStudentSurveyResponse>(studentSurvey);
            return response;
        }
    }
}