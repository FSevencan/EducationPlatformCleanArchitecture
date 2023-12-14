using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ApplicationEducationRepository : EfRepositoryBase<ApplicationEducation, Guid, BaseDbContext>, IApplicationEducationRepository
{
    public ApplicationEducationRepository(BaseDbContext context) : base(context)
    {
    }
}