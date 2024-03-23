using Application.Features.UserAnswers.Constants;
using Application.Features.UserAnswers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserAnswers.Constants.UserAnswersOperationClaims;
using Core.Security.Entities;

namespace Application.Features.UserAnswers.Commands.Update;

public class UpdateUserAnswerCommand : IRequest<UpdatedUserAnswerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ChoiceId { get; set; }
    public Guid QuestionId { get; set; }
    public string AnswerText { get; set; }
   

    public string[] Roles => new[] { Admin, Write, UserAnswersOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserAnswers";

    public class UpdateUserAnswerCommandHandler : IRequestHandler<UpdateUserAnswerCommand, UpdatedUserAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly UserAnswerBusinessRules _userAnswerBusinessRules;

        public UpdateUserAnswerCommandHandler(IMapper mapper, IUserAnswerRepository userAnswerRepository,
                                         UserAnswerBusinessRules userAnswerBusinessRules)
        {
            _mapper = mapper;
            _userAnswerRepository = userAnswerRepository;
            _userAnswerBusinessRules = userAnswerBusinessRules;
        }

        public async Task<UpdatedUserAnswerResponse> Handle(UpdateUserAnswerCommand request, CancellationToken cancellationToken)
        {
            UserAnswer? userAnswer = await _userAnswerRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAnswerBusinessRules.UserAnswerShouldExistWhenSelected(userAnswer);
            userAnswer = _mapper.Map(request, userAnswer);

            await _userAnswerRepository.UpdateAsync(userAnswer!);

            UpdatedUserAnswerResponse response = _mapper.Map<UpdatedUserAnswerResponse>(userAnswer);
            return response;
        }
    }
}