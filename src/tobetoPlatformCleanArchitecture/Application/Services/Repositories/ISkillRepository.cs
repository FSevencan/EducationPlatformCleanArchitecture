using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISkillRepository : IAsyncRepository<Skill, Guid>, IRepository<Skill, Guid>
{
}