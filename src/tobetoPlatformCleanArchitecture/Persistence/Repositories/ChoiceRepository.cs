using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ChoiceRepository : EfRepositoryBase<Choice, Guid, BaseDbContext>, IChoiceRepository
{
    public ChoiceRepository(BaseDbContext context) : base(context)
    {
    }
}