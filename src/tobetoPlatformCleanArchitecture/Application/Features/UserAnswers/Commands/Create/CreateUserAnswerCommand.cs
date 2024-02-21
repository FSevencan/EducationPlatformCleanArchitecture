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

namespace Application.Features.UserAnswers.Commands.Create;

public class CreateUserAnswerCommand : IRequest<CreatedUserAnswerResponse>/*, ISecuredRequest*/, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int UserId { get; set; }
    public Guid ExamId { get; set; }
    public int? CorrectCount { get; set; }
    public int? WrongCount { get; set; }
    public int? EmptyCount { get; set; }
    public int? TotalScore { get; set; }

    public string[] Roles => new[] { Admin, Write, UserAnswersOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetUserAnswers";

    public class CreateUserAnswerCommandHandler : IRequestHandler<CreateUserAnswerCommand, CreatedUserAnswerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly UserAnswerBusinessRules _userAnswerBusinessRules;

        public CreateUserAnswerCommandHandler(IMapper mapper, IUserAnswerRepository userAnswerRepository,
                                         UserAnswerBusinessRules userAnswerBusinessRules)
        {
            _mapper = mapper;
            _userAnswerRepository = userAnswerRepository;
            _userAnswerBusinessRules = userAnswerBusinessRules;
        }

        public async Task<CreatedUserAnswerResponse> Handle(CreateUserAnswerCommand request, CancellationToken cancellationToken)
        {
            UserAnswer userAnswer = _mapper.Map<UserAnswer>(request);

            await _userAnswerRepository.AddAsync(userAnswer);

            CreatedUserAnswerResponse response = _mapper.Map<CreatedUserAnswerResponse>(userAnswer);
            return response;
        }
    }
}