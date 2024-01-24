using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICampusEncounterRepository : IAsyncRepository<CampusEncounter, Guid>, IRepository<CampusEncounter, Guid>
{
}