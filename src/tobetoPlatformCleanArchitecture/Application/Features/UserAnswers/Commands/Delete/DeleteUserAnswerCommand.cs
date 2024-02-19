using Application.Features.UserAnswers.Constants;
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

namespace Application.Features.UserAnswers.Commands.Delete;

public class DeleteUserAnswerCommand : IRequest<DeletedUserAnswerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, UserAnswersOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserAnswers";

    public class DeleteUserAnswerCommandHandler : IRequestHandler<DeleteUserAnswerCommand, DeletedUserAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly UserAnswerBusinessRules _userAnswerBusinessRules;

        public DeleteUserAnswerCommandHandler(IMapper mapper, IUserAnswerRepository userAnswerRepository,
                                         UserAnswerBusinessRules userAnswerBusinessRules)
        {
            _mapper = mapper;
            _userAnswerRepository = userAnswerRepository;
            _userAnswerBusinessRules = userAnswerBusinessRules;
        }

        public async Task<DeletedUserAnswerResponse> Handle(DeleteUserAnswerCommand request, CancellationToken cancellationToken)
        {
            UserAnswer? userAnswer = await _userAnswerRepository.GetAsync(predicate: ua => ua.Id == request.Id, cancellationToken: cancellationToken);
            await _userAnswerBusinessRules.UserAnswerShouldExistWhenSelected(userAnswer);

            await _userAnswerRepository.DeleteAsync(userAnswer!);

            DeletedUserAnswerResponse response = _mapper.Map<DeletedUserAnswerResponse>(userAnswer);
            return response;
        }
    }
}