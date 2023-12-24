using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassRoomTypeRepository : EfRepositoryBase<ClassRoomType, Guid, BaseDbContext>, IClassRoomTypeRepository
{
    public ClassRoomTypeRepository(BaseDbContext context) : base(context)
    {
    }
}