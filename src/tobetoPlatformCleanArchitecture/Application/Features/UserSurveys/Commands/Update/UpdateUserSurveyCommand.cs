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

namespace Application.Features.UserSurveys.Commands.Update;

public class UpdateUserSurveyCommand : IRequest<UpdatedUserSurveyResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid SurveyId { get; set; }

    public string[] Roles => new[] { Admin, Write, UserSurveysOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserSurveys";

    public class UpdateUserSurveyCommandHandler : IRequestHandler<UpdateUserSurveyCommand, UpdatedUserSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSurveyRepository _userSurveyRepository;
        private readonly UserSurveyBusinessRules _userSurveyBusinessRules;

        public UpdateUserSurveyCommandHandler(IMapper mapper, IUserSurveyRepository userSurveyRepository,
                                         UserSurveyBusinessRules userSurveyBusinessRules)
        {
            _mapper = mapper;
            _userSurveyRepository = userSurveyRepository;
            _userSurveyBusinessRules = userSurveyBusinessRules;
        }

        public async Task<UpdatedUserSurveyResponse> Handle(UpdateUserSurveyCommand request, CancellationToken cancellationToken)
        {
            UserSurvey? userSurvey = await _userSurveyRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userSurveyBusinessRules.UserSurveyShouldExistWhenSelected(userSurvey);
            userSurvey = _mapper.Map(request, userSurvey);

            await _userSurveyRepository.UpdateAsync(userSurvey!);

            UpdatedUserSurveyResponse response = _mapper.Map<UpdatedUserSurveyResponse>(userSurvey);
            return response;
        }
    }
}