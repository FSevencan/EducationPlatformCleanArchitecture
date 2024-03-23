using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentClassRoomRepository : IAsyncRepository<StudentClassRoom, Guid>, IRepository<StudentClassRoom, Guid>
{
}