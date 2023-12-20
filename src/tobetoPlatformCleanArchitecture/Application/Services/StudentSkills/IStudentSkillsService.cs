using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentSkills;

public interface IStudentSkillsService
{
    Task<StudentSkill?> GetAsync(
        Expression<Func<StudentSkill, bool>> predicate,
        Func<IQueryable<StudentSkill>, IIncludableQueryable<StudentSkill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentSkill>?> GetListAsync(
        Expression<Func<StudentSkill, bool>>? predicate = null,
        Func<IQueryable<StudentSkill>, IOrderedQueryable<StudentSkill>>? orderBy = null,
        Func<IQueryable<StudentSkill>, IIncludableQueryable<StudentSkill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentSkill> AddAsync(StudentSkill studentSkill);
    Task<StudentSkill> UpdateAsync(StudentSkill studentSkill);
    Task<StudentSkill> DeleteAsync(StudentSkill studentSkill, bool permanent = false);
}
