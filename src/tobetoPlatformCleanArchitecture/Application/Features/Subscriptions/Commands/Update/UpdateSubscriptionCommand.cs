using Application.Features.Subscriptions.Constants;
using Application.Features.Subscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Subscriptions.Constants.SubscriptionsOperationClaims;

namespace Application.Features.Subscriptions.Commands.Update;

public class UpdateSubscriptionCommand : IRequest<UpdatedSubscriptionResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public Guid ClassRoomTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, SubscriptionsOperationClaims.Update };

    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, UpdatedSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

        public UpdateSubscriptionCommandHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository,
                                         SubscriptionBusinessRules subscriptionBusinessRules)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionBusinessRules = subscriptionBusinessRules;
        }

        public async Task<UpdatedSubscriptionResponse> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            Subscription? subscription = await _subscriptionRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _subscriptionBusinessRules.SubscriptionShouldExistWhenSelected(subscription);
            subscription = _mapper.Map(request, subscription);

            await _subscriptionRepository.UpdateAsync(subscription!);

            UpdatedSubscriptionResponse response = _mapper.Map<UpdatedSubscriptionResponse>(subscription);
            return response;
        }
    }
}