using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnnouncementRepository : EfRepositoryBase<Announcement, Guid, BaseDbContext>, IAnnouncementRepository
{
    public AnnouncementRepository(BaseDbContext context) : base(context)
    {
    }
}