using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SectionAboutRepository : EfRepositoryBase<SectionAbout, Guid, BaseDbContext>, ISectionAboutRepository
{
    public SectionAboutRepository(BaseDbContext context) : base(context)
    {
    }
}