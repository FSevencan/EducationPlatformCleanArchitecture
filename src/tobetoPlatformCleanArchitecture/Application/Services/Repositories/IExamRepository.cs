using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IExamRepository : IAsyncRepository<Exam, Guid>, IRepository<Exam, Guid>
{
}