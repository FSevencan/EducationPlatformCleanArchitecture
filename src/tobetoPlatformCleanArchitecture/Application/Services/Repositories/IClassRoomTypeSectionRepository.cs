using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IClassRoomTypeSectionRepository : IAsyncRepository<ClassRoomTypeSection, Guid>, IRepository<ClassRoomTypeSection, Guid>
{
}