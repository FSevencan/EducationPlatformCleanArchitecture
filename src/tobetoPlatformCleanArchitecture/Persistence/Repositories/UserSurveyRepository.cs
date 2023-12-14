using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserSurveyRepository : EfRepositoryBase<UserSurvey, Guid, BaseDbContext>, IUserSurveyRepository
{
    public UserSurveyRepository(BaseDbContext context) : base(context)
    {
    }
}