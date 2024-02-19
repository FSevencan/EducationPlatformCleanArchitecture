using Application.Features.UserAnswers.Constants;
using Application.Features.UserAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserAnswers.Constants.UserAnswersOperationClaims;

namespace Application.Features.UserAnswers.Queries.GetById;

public class GetByIdUserAnswerQuery : IRequest<GetByIdUserAnswerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdUserAnswerQueryHandler : IRequestHandler<GetByIdUserAnswerQuery, GetByIdUserAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly UserAnswerBusinessRules _userAnswerBusinessRules;

        public GetByIdUserAnswerQueryHandler(IMapper mapper, IUserAnswerRepository userAnswerRepository, UserAnswerBusinessRules userAnswerBusinessRules)
        {
            _mapper = mapper;
            _userAnswerRepository = userAnswerRepository;
            _userAnswerBusinessRules = userAnswerBusinessRules;
        }

        public async Task<GetByIdUserAnswerResponse> Handle(GetByIdUserAnswerQuery request, CancellationToken cancellationToken)
        {
            UserAnswer? userAnswer = await _userAnswerRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAnswerBusinessRules.UserAnswerShouldExistWhenSelected(userAnswer);

            GetByIdUserAnswerResponse response = _mapper.Map<GetByIdUserAnswerResponse>(userAnswer);
            return response;
        }
    }
}