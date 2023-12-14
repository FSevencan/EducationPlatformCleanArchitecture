using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IApplicationEducationRepository : IAsyncRepository<ApplicationEducation, Guid>, IRepository<ApplicationEducation, Guid>
{
}