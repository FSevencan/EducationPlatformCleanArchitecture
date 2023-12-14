using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserSectionRepository : IAsyncRepository<UserSection, Guid>, IRepository<UserSection, Guid>
{
}