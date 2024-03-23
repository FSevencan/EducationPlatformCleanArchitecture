using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SubscriptionRepository : EfRepositoryBase<Subscription, Guid, BaseDbContext>, ISubscriptionRepository
{
    public SubscriptionRepository(BaseDbContext context) : base(context)
    {
    }
}