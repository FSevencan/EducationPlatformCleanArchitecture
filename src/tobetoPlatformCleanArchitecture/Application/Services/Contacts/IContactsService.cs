using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Contacts;

public interface IContactsService
{
    Task<Contact?> GetAsync(
        Expression<Func<Contact, bool>> predicate,
        Func<IQueryable<Contact>, IIncludableQueryable<Contact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Contact>?> GetListAsync(
        Expression<Func<Contact, bool>>? predicate = null,
        Func<IQueryable<Contact>, IOrderedQueryable<Contact>>? orderBy = null,
        Func<IQueryable<Contact>, IIncludableQueryable<Contact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Contact> AddAsync(Contact contact);
    Task<Contact> UpdateAsync(Contact contact);
    Task<Contact> DeleteAsync(Contact contact, bool permanent = false);
}
