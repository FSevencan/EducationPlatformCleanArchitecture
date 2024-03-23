using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CampusEncounterRepository : EfRepositoryBase<CampusEncounter, Guid, BaseDbContext>, ICampusEncounterRepository
{
    public CampusEncounterRepository(BaseDbContext context) : base(context)
    {
    }
}