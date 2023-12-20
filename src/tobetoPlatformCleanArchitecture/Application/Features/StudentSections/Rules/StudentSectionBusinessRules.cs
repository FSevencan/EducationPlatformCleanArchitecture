using Application.Features.StudentSections.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentSections.Rules;

public class StudentSectionBusinessRules : BaseBusinessRules
{
    private readonly IStudentSectionRepository _studentSectionRepository;

    public StudentSectionBusinessRules(IStudentSectionRepository studentSectionRepository)
    {
        _studentSectionRepository = studentSectionRepository;
    }

    public Task StudentSectionShouldExistWhenSelected(StudentSection? studentSection)
    {
        if (studentSection == null)
            throw new BusinessException(StudentSectionsBusinessMessages.StudentSectionNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentSectionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentSection? studentSection = await _studentSectionRepository.GetAsync(
            predicate: ss => ss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentSectionShouldExistWhenSelected(studentSection);
    }
}