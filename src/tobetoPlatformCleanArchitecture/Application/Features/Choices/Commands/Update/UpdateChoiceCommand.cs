using Application.Features.Choices.Constants;
using Application.Features.Choices.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Choices.Constants.ChoicesOperationClaims;

namespace Application.Features.Choices.Commands.Update;

public class UpdateChoiceCommand : IRequest<UpdatedChoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public Question Question { get; set; }

    public string[] Roles => new[] { Admin, Write, ChoicesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetChoices";

    public class UpdateChoiceCommandHandler : IRequestHandler<UpdateChoiceCommand, UpdatedChoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChoiceRepository _choiceRepository;
        private readonly ChoiceBusinessRules _choiceBusinessRules;

        public UpdateChoiceCommandHandler(IMapper mapper, IChoiceRepository choiceRepository,
                                         ChoiceBusinessRules choiceBusinessRules)
        {
            _mapper = mapper;
            _choiceRepository = choiceRepository;
            _choiceBusinessRules = choiceBusinessRules;
        }

        public async Task<UpdatedChoiceResponse> Handle(UpdateChoiceCommand request, CancellationToken cancellationToken)
        {
            Choice? choice = await _choiceRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _choiceBusinessRules.ChoiceShouldExistWhenSelected(choice);
            choice = _mapper.Map(request, choice);

            await _choiceRepository.UpdateAsync(choice!);

            UpdatedChoiceResponse response = _mapper.Map<UpdatedChoiceResponse>(choice);
            return response;
        }
    }
}