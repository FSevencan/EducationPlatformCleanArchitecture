using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassRoomTypeSectionRepository : EfRepositoryBase<ClassRoomTypeSection, Guid, BaseDbContext>, IClassRoomTypeSectionRepository
{
    public ClassRoomTypeSectionRepository(BaseDbContext context) : base(context)
    {
    }
}