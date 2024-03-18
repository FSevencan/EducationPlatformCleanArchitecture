using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILikeRepository : IAsyncRepository<Like, Guid>, IRepository<Like, Guid>
{
}