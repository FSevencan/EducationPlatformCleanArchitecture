using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentSectionRepository : EfRepositoryBase<StudentClassRoom, Guid, BaseDbContext>, IStudentSectionRepository
{
    public StudentSectionRepository(BaseDbContext context) : base(context)
    {
    }
}