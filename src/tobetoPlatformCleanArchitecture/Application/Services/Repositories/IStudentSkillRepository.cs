using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentSkillRepository : IAsyncRepository<StudentSkill, Guid>, IRepository<StudentSkill, Guid>
{
}