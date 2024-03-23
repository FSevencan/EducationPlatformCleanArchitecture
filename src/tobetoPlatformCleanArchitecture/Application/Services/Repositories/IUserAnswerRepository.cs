using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserAnswerRepository : IAsyncRepository<UserAnswer, Guid>, IRepository<UserAnswer, Guid>
{
}