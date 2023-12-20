using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICertificateRepository : IAsyncRepository<Certificate, Guid>, IRepository<Certificate, Guid>
{
}