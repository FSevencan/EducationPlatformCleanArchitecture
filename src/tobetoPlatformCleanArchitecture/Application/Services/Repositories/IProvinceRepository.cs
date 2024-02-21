using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProvinceRepository : IAsyncRepository<Province, int>, IRepository<Province, int>
{
}