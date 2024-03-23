using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MentorshipSessionRepository : EfRepositoryBase<MentorshipSession, Guid, BaseDbContext>, IMentorshipSessionRepository
{
    public MentorshipSessionRepository(BaseDbContext context) : base(context)
    {
    }
}