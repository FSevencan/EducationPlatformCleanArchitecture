using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Subscriptions.Queries.GetSubscriptionsByUserId;
public class GetSubscriptionByUserIdQuery : MediatR.IRequest<GetSubscriptionByUserIdResponse>
{
    public int UserId { get; set; }

    public class GetSubscriptionByUserIdQueryHandler : IRequestHandler<GetSubscriptionByUserIdQuery, GetSubscriptionByUserIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionByUserIdQueryHandler(IMapper mapper, ISubscriptionRepository subscriptionRepository)
        {
            _mapper = mapper;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<GetSubscriptionByUserIdResponse> Handle(GetSubscriptionByUserIdQuery request, CancellationToken cancellationToken)
        {
           
            var subscription = await _subscriptionRepository.GetAsync(
                predicate: s => s.UserId == request.UserId,
                include: c=> c.Include(c=> c.ClassRoomType),
                cancellationToken: cancellationToken);

            GetSubscriptionByUserIdResponse subscriptionDto = _mapper.Map<GetSubscriptionByUserIdResponse>(subscription);

            return subscriptionDto;
        }
    }
}

