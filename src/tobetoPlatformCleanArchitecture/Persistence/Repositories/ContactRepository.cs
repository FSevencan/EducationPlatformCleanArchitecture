using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ContactRepository : EfRepositoryBase<Contact, Guid, BaseDbContext>, IContactRepository
{
    public ContactRepository(BaseDbContext context) : base(context)
    {
    }
}