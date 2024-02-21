using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProvinceRepository : EfRepositoryBase<Province, int, BaseDbContext>, IProvinceRepository
{
    public ProvinceRepository(BaseDbContext context) : base(context)
    {
    }
}