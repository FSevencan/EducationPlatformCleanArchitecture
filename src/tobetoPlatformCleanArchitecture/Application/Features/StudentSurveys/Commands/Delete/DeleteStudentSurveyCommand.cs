using Application.Features.StudentSurveys.Constants;
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

namespace Application.Features.StudentSurveys.Commands.Delete;

public class DeleteStudentSurveyCommand : IRequest<DeletedStudentSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentSurveysOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetStudentSurveys";

    public class DeleteStudentSurveyCommandHandler : IRequestHandler<DeleteStudentSurveyCommand, DeletedStudentSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSurveyRepository _studentSurveyRepository;
        private readonly StudentSurveyBusinessRules _studentSurveyBusinessRules;

        public DeleteStudentSurveyCommandHandler(IMapper mapper, IStudentSurveyRepository studentSurveyRepository,
                                         StudentSurveyBusinessRules studentSurveyBusinessRules)
        {
            _mapper = mapper;
            _studentSurveyRepository = studentSurveyRepository;
            _studentSurveyBusinessRules = studentSurveyBusinessRules;
        }

        public async Task<DeletedStudentSurveyResponse> Handle(DeleteStudentSurveyCommand request, CancellationToken cancellationToken)
        {
            StudentSurvey? studentSurvey = await _studentSurveyRepository.GetAsync(predicate: ss => ss.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSurveyBusinessRules.StudentSurveyShouldExistWhenSelected(studentSurvey);

            await _studentSurveyRepository.DeleteAsync(studentSurvey!);

            DeletedStudentSurveyResponse response = _mapper.Map<DeletedStudentSurveyResponse>(studentSurvey);
            return response;
        }
    }
}