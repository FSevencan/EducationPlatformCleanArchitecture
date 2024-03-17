using Application.Features.Subscriptions.Constants;
using Application.Features.Subscriptions.Constants;
using Application.Features.Subscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Subscriptions.Constants.SubscriptionsOperationClaims;

namespace Application.Features.Subscriptions.Commands.Delete;

public class DeleteSubscriptionCommand : IRequest<DeletedSubscriptionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => new[] { Admin, SubscriptionsOperationClaims.Student, Write, SubscriptionsOperationClaims.Delete };

    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, DeletedSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

        public DeleteSubscriptionCommandHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository,
                                         SubscriptionBusinessRules subscriptionBusinessRules)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionBusinessRules = subscriptionBusinessRules;
        }

        public async Task<DeletedSubscriptionResponse> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription? subscription = await _subscriptionRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _subscriptionBusinessRules.SubscriptionShouldExistWhenSelected(subscription);

            await _subscriptionRepository.DeleteAsync(subscription!);

            DeletedSubscriptionResponse response = _mapper.Map<DeletedSubscriptionResponse>(subscription);
            return response;
        }
    }
}