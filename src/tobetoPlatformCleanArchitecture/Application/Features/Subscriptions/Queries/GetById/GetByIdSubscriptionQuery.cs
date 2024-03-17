using Application.Features.Subscriptions.Constants;
using Application.Features.Subscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Subscriptions.Constants.SubscriptionsOperationClaims;

namespace Application.Features.Subscriptions.Queries.GetById;

public class GetByIdSubscriptionQuery : IRequest<GetByIdSubscriptionResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSubscriptionQueryHandler : IRequestHandler<GetByIdSubscriptionQuery, GetByIdSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

        public GetByIdSubscriptionQueryHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository, SubscriptionBusinessRules subscriptionBusinessRules)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionBusinessRules = subscriptionBusinessRules;
        }

        public async Task<GetByIdSubscriptionResponse> Handle(GetByIdSubscriptionQuery request, CancellationToken cancellationToken)
        {
            Subscription? subscription = await _subscriptionRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _subscriptionBusinessRules.SubscriptionShouldExistWhenSelected(subscription);

            GetByIdSubscriptionResponse response = _mapper.Map<GetByIdSubscriptionResponse>(subscription);
            return response;
        }
    }
}