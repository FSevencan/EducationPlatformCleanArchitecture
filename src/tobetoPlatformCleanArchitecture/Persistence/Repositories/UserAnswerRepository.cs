using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserAnswerRepository : EfRepositoryBase<UserAnswer, Guid, BaseDbContext>, IUserAnswerRepository
{
    public UserAnswerRepository(BaseDbContext context) : base(context)
    {
    }
}