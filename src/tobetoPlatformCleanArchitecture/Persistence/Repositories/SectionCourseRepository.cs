using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SectionCourseRepository : EfRepositoryBase<SectionCourse, Guid, BaseDbContext>, ISectionCourseRepository
{
    public SectionCourseRepository(BaseDbContext context) : base(context)
    {
    }
}