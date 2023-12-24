using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentSectionRepository : IAsyncRepository<StudentClassRoom, Guid>, IRepository<StudentClassRoom, Guid>
{
}