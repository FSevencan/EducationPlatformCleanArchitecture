using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SkillRepository : EfRepositoryBase<Skill, Guid, BaseDbContext>, ISkillRepository
{
    public SkillRepository(BaseDbContext context) : base(context)
    {
    }
}