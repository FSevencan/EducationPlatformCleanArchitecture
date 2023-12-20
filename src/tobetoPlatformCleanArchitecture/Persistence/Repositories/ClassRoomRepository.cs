using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassRoomRepository : EfRepositoryBase<ClassRoom, Guid, BaseDbContext>, IClassRoomRepository
{
    public ClassRoomRepository(BaseDbContext context) : base(context)
    {
    }
}