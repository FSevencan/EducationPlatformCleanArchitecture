using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Skills;

public interface ISkillsService
{
    Task<Skill?> GetAsync(
        Expression<Func<Skill, bool>> predicate,
        Func<IQueryable<Skill>, IIncludableQueryable<Skill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Skill>?> GetListAsync(
        Expression<Func<Skill, bool>>? predicate = null,
        Func<IQueryable<Skill>, IOrderedQueryable<Skill>>? orderBy = null,
        Func<IQueryable<Skill>, IIncludableQueryable<Skill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Skill> AddAsync(Skill skill);
    Task<Skill> UpdateAsync(Skill skill);
    Task<Skill> DeleteAsync(Skill skill, bool permanent = false);
}
