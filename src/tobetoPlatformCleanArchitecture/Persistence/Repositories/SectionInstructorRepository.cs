using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SectionInstructorRepository : EfRepositoryBase<SectionInstructor, Guid, BaseDbContext>, ISectionInstructorRepository
{
    public SectionInstructorRepository(BaseDbContext context) : base(context)
    {
    }
}