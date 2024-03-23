using Application.Features.StudentSkills.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentSkills.Rules;

public class StudentSkillBusinessRules : BaseBusinessRules
{
    private readonly IStudentSkillRepository _studentSkillRepository;

    public StudentSkillBusinessRules(IStudentSkillRepository studentSkillRepository)
    {
        _studentSkillRepository = studentSkillRepository;
    }

    public Task StudentSkillShouldExistWhenSelected(StudentSkill? studentSkill)
    {
        if (studentSkill == null)
            throw new BusinessException(StudentSkillsBusinessMessages.StudentSkillNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentSkillIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentSkill? studentSkill = await _studentSkillRepository.GetAsync(
            predicate: ss => ss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentSkillShouldExistWhenSelected(studentSkill);
    }
}