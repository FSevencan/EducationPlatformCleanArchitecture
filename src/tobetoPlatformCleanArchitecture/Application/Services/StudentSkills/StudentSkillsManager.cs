using Application.Features.StudentSkills.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentSkills;

public class StudentSkillsManager : IStudentSkillsService
{
    private readonly IStudentSkillRepository _studentSkillRepository;
    private readonly StudentSkillBusinessRules _studentSkillBusinessRules;

    public StudentSkillsManager(IStudentSkillRepository studentSkillRepository, StudentSkillBusinessRules studentSkillBusinessRules)
    {
        _studentSkillRepository = studentSkillRepository;
        _studentSkillBusinessRules = studentSkillBusinessRules;
    }

    public async Task<StudentSkill?> GetAsync(
        Expression<Func<StudentSkill, bool>> predicate,
        Func<IQueryable<StudentSkill>, IIncludableQueryable<StudentSkill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentSkill? studentSkill = await _studentSkillRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentSkill;
    }

    public async Task<IPaginate<StudentSkill>?> GetListAsync(
        Expression<Func<StudentSkill, bool>>? predicate = null,
        Func<IQueryable<StudentSkill>, IOrderedQueryable<StudentSkill>>? orderBy = null,
        Func<IQueryable<StudentSkill>, IIncludableQueryable<StudentSkill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentSkill> studentSkillList = await _studentSkillRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentSkillList;
    }

    public async Task<StudentSkill> AddAsync(StudentSkill studentSkill)
    {
        StudentSkill addedStudentSkill = await _studentSkillRepository.AddAsync(studentSkill);

        return addedStudentSkill;
    }

    public async Task<StudentSkill> UpdateAsync(StudentSkill studentSkill)
    {
        StudentSkill updatedStudentSkill = await _studentSkillRepository.UpdateAsync(studentSkill);

        return updatedStudentSkill;
    }

    public async Task<StudentSkill> DeleteAsync(StudentSkill studentSkill, bool permanent = false)
    {
        StudentSkill deletedStudentSkill = await _studentSkillRepository.DeleteAsync(studentSkill);

        return deletedStudentSkill;
    }
}
