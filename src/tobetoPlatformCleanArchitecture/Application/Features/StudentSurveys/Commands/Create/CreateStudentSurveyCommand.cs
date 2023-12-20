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

namespace Application.Features.StudentSurveys.Commands.Create;

public class CreateStudentSurveyCommand : IRequest<CreatedStudentSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int StudentId { get; set; }
    public Guid SurveyId { get; set; }
    public Student Student { get; set; }
    public Survey Survey { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSurveysOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSurveys";

    public class CreateStudentSurveyCommandHandler : IRequestHandler<CreateStudentSurveyCommand, CreatedStudentSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSurveyRepository _studentSurveyRepository;
        private readonly StudentSurveyBusinessRules _studentSurveyBusinessRules;

        public CreateStudentSurveyCommandHandler(IMapper mapper, IStudentSurveyRepository studentSurveyRepository,
                                         StudentSurveyBusinessRules studentSurveyBusinessRules)
        {
            _mapper = mapper;
            _studentSurveyRepository = studentSurveyRepository;
            _studentSurveyBusinessRules = studentSurveyBusinessRules;
        }

        public async Task<CreatedStudentSurveyResponse> Handle(CreateStudentSurveyCommand request, CancellationToken cancellationToken)
        {
            StudentSurvey studentSurvey = _mapper.Map<StudentSurvey>(request);

            await _studentSurveyRepository.AddAsync(studentSurvey);

            CreatedStudentSurveyResponse response = _mapper.Map<CreatedStudentSurveyResponse>(studentSurvey);
            return response;
        }
    }
}