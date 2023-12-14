using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserSurveyRepository : IAsyncRepository<UserSurvey, Guid>, IRepository<UserSurvey, Guid>
{
}