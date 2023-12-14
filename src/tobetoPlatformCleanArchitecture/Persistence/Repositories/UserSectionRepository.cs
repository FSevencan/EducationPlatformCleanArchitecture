using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserSectionRepository : EfRepositoryBase<UserSection, Guid, BaseDbContext>, IUserSectionRepository
{
    public UserSectionRepository(BaseDbContext context) : base(context)
    {
    }
}