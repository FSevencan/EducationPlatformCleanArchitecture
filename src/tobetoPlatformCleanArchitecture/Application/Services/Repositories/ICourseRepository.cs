using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICourseRepository : IAsyncRepository<Course, Guid>, IRepository<Course, Guid>
{
}