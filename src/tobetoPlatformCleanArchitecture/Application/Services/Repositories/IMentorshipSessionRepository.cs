using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMentorshipSessionRepository : IAsyncRepository<MentorshipSession, Guid>, IRepository<MentorshipSession, Guid>
{
}