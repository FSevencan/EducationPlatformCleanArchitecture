using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassRoomTypeRepository : IAsyncRepository<ClassRoomType, Guid>, IRepository<ClassRoomType, Guid>
{
}