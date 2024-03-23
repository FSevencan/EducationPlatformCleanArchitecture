using Application.Features.Choices.Constants;
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

namespace Application.Features.Choices.Commands.Delete;

public class DeleteChoiceCommand : IRequest<DeletedChoiceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ChoicesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetChoices";

    public class DeleteChoiceCommandHandler : IRequestHandler<DeleteChoiceCommand, DeletedChoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IChoiceRepository _choiceRepository;
        private readonly ChoiceBusinessRules _choiceBusinessRules;

        public DeleteChoiceCommandHandler(IMapper mapper, IChoiceRepository choiceRepository,
                                         ChoiceBusinessRules choiceBusinessRules)
        {
            _mapper = mapper;
            _choiceRepository = choiceRepository;
            _choiceBusinessRules = choiceBusinessRules;
        }

        public async Task<DeletedChoiceResponse> Handle(DeleteChoiceCommand request, CancellationToken cancellationToken)
        {
            Choice? choice = await _choiceRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _choiceBusinessRules.ChoiceShouldExistWhenSelected(choice);

            await _choiceRepository.DeleteAsync(choice!);

            DeletedChoiceResponse response = _mapper.Map<DeletedChoiceResponse>(choice);
            return response;
        }
    }
}