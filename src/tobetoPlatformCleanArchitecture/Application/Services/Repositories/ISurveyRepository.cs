using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISurveyRepository : IAsyncRepository<Survey, Guid>, IRepository<Survey, Guid>
{
}