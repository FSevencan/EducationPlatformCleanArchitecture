using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISectionCourseRepository : IAsyncRepository<SectionCourse, Guid>, IRepository<SectionCourse, Guid>
{
}