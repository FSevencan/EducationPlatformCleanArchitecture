using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISectionAboutRepository : IAsyncRepository<SectionAbout, Guid>, IRepository<SectionAbout, Guid>
{
}