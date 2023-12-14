using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILanguageRepository : IAsyncRepository<Language, Guid>, IRepository<Language, Guid>
{
}