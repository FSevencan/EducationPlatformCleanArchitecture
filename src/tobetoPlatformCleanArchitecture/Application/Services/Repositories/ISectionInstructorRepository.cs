using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISectionInstructorRepository : IAsyncRepository<SectionInstructor, Guid>, IRepository<SectionInstructor, Guid>
{
}