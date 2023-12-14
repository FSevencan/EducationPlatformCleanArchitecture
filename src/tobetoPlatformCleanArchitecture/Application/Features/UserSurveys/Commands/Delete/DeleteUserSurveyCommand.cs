using Application.Features.UserSurveys.Constants;
using Application.Features.UserSurveys.Constants;
using Application.Features.UserSurveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserSurveys.Constants.UserSurveysOperationClaims;

namespace Application.Features.UserSurveys.Commands.Delete;

public class DeleteUserSurveyCommand : IRequest<DeletedUserSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, UserSurveysOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserSurveys";

    public class DeleteUserSurveyCommandHandler : IRequestHandler<DeleteUserSurveyCommand, DeletedUserSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSurveyRepository _userSurveyRepository;
        private readonly UserSurveyBusinessRules _userSurveyBusinessRules;

        public DeleteUserSurveyCommandHandler(IMapper mapper, IUserSurveyRepository userSurveyRepository,
                                         UserSurveyBusinessRules userSurveyBusinessRules)
        {
            _mapper = mapper;
            _userSurveyRepository = userSurveyRepository;
            _userSurveyBusinessRules = userSurveyBusinessRules;
        }

        public async Task<DeletedUserSurveyResponse> Handle(DeleteUserSurveyCommand request, CancellationToken cancellationToken)
        {
            UserSurvey? userSurvey = await _userSurveyRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userSurveyBusinessRules.UserSurveyShouldExistWhenSelected(userSurvey);

            await _userSurveyRepository.DeleteAsync(userSurvey!);

            DeletedUserSurveyResponse response = _mapper.Map<DeletedUserSurveyResponse>(userSurvey);
            return response;
        }
    }
}