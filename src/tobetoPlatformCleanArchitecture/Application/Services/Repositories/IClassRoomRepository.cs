using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassRoomRepository : IAsyncRepository<ClassRoom, Guid>, IRepository<ClassRoom, Guid>
{
}