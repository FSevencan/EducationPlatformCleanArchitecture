using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SectionRepository : EfRepositoryBase<Section, Guid, BaseDbContext>, ISectionRepository
{
    public SectionRepository(BaseDbContext context) : base(context)
    {
    }
}