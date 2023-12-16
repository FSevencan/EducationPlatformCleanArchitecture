using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAppUserRepository : IAsyncRepository<AppUser, int>, IRepository<AppUser, int>
{
}