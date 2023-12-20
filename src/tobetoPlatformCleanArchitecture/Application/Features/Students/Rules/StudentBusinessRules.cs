using Application.Features.Students.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Students.Rules;

public class StudentBusinessRules : BaseBusinessRules
{
    private readonly IStudentRepository _studentRepository;

    public StudentBusinessRules(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public Task StudentShouldExistWhenSelected(Student? student)
    {
        if (student == null)
            throw new BusinessException(StudentsBusinessMessages.StudentNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Student? student = await _studentRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentShouldExistWhenSelected(student);
    }
}