using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProducerCompanyRepository : EfRepositoryBase<ProducerCompany, Guid, BaseDbContext>, IProducerCompanyRepository
{
    public ProducerCompanyRepository(BaseDbContext context) : base(context)
    {
    }
}