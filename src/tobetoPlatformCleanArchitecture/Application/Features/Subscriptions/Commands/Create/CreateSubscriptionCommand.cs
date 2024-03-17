using Application.Features.Subscriptions.Constants;
using Application.Features.Subscriptions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Subscriptions.Constants.SubscriptionsOperationClaims;

namespace Application.Features.Subscriptions.Commands.Create;

public class CreateSubscriptionCommand : IRequest<CreatedSubscriptionResponse>
{
    public int UserId { get; set; }
    public Guid ClassRoomTypeId { get; set; }

    public string[] Roles => new[] { Admin, Write, SubscriptionsOperationClaims.Create };

    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, CreatedSubscriptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly SubscriptionBusinessRules _subscriptionBusinessRules;

        public CreateSubscriptionCommandHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository,
                                         SubscriptionBusinessRules subscriptionBusinessRules)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
            _subscriptionBusinessRules = subscriptionBusinessRules;
        }

        public async Task<CreatedSubscriptionResponse> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            await _subscriptionBusinessRules.UserShouldNotAlreadyBeSubscribed(request.UserId, request.ClassRoomTypeId);

            Subscription subscription = _mapper.Map<Subscription>(request);

            await _subscriptionRepository.AddAsync(subscription);

            CreatedSubscriptionResponse response = _mapper.Map<CreatedSubscriptionResponse>(subscription);
            return response;
        }
    }
}