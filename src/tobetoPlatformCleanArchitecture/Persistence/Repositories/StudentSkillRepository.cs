using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentSkillRepository : EfRepositoryBase<StudentSkill, Guid, BaseDbContext>, IStudentSkillRepository
{
    public StudentSkillRepository(BaseDbContext context) : base(context)
    {
    }
}