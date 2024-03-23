using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISubscriptionRepository : IAsyncRepository<Subscription, Guid>, IRepository<Subscription, Guid>
{
}