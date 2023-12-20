using Application.Features.Skills.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Skills;

public class SkillsManager : ISkillsService
{
    private readonly ISkillRepository _skillRepository;
    private readonly SkillBusinessRules _skillBusinessRules;

    public SkillsManager(ISkillRepository skillRepository, SkillBusinessRules skillBusinessRules)
    {
        _skillRepository = skillRepository;
        _skillBusinessRules = skillBusinessRules;
    }

    public async Task<Skill?> GetAsync(
        Expression<Func<Skill, bool>> predicate,
        Func<IQueryable<Skill>, IIncludableQueryable<Skill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Skill? skill = await _skillRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return skill;
    }

    public async Task<IPaginate<Skill>?> GetListAsync(
        Expression<Func<Skill, bool>>? predicate = null,
        Func<IQueryable<Skill>, IOrderedQueryable<Skill>>? orderBy = null,
        Func<IQueryable<Skill>, IIncludableQueryable<Skill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Skill> skillList = await _skillRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return skillList;
    }

    public async Task<Skill> AddAsync(Skill skill)
    {
        Skill addedSkill = await _skillRepository.AddAsync(skill);

        return addedSkill;
    }

    public async Task<Skill> UpdateAsync(Skill skill)
    {
        Skill updatedSkill = await _skillRepository.UpdateAsync(skill);

        return updatedSkill;
    }

    public async Task<Skill> DeleteAsync(Skill skill, bool permanent = false)
    {
        Skill deletedSkill = await _skillRepository.DeleteAsync(skill);

        return deletedSkill;
    }
}
