using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISectionRepository : IAsyncRepository<Section, Guid>, IRepository<Section, Guid>
{
}