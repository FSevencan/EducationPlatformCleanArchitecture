using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentSectionRepository : IAsyncRepository<StudentSection, Guid>, IRepository<StudentSection, Guid>
{
}