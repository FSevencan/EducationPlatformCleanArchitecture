using Application.Features.UserSurveys.Constants;
using Application.Features.UserSurveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserSurveys.Constants.UserSurveysOperationClaims;

namespace Application.Features.UserSurveys.Queries.GetById;

public class GetByIdUserSurveyQuery : IRequest<GetByIdUserSurveyResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdUserSurveyQueryHandler : IRequestHandler<GetByIdUserSurveyQuery, GetByIdUserSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserSurveyRepository _userSurveyRepository;
        private readonly UserSurveyBusinessRules _userSurveyBusinessRules;

        public GetByIdUserSurveyQueryHandler(IMapper mapper, IUserSurveyRepository userSurveyRepository, UserSurveyBusinessRules userSurveyBusinessRules)
        {
            _mapper = mapper;
            _userSurveyRepository = userSurveyRepository;
            _userSurveyBusinessRules = userSurveyBusinessRules;
        }

        public async Task<GetByIdUserSurveyResponse> Handle(GetByIdUserSurveyQuery request, CancellationToken cancellationToken)
        {
            UserSurvey? userSurvey = await _userSurveyRepository.GetAsync(predicate: us => us.Id == request.Id, cancellationToken: cancellationToken);
            await _userSurveyBusinessRules.UserSurveyShouldExistWhenSelected(userSurvey);

            GetByIdUserSurveyResponse response = _mapper.Map<GetByIdUserSurveyResponse>(userSurvey);
            return response;
        }
    }
}