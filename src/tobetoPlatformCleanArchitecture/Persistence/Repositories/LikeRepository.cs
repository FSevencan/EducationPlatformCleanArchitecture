using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LikeRepository : EfRepositoryBase<Like, Guid, BaseDbContext>, ILikeRepository
{
    public LikeRepository(BaseDbContext context) : base(context)
    {
    }
}