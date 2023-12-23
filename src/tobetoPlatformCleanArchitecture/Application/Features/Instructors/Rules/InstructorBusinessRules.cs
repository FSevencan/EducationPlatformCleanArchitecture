using Application.Features.Instructors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Instructors.Rules;

public class InstructorBusinessRules : BaseBusinessRules
{
    private readonly IInstructorRepository _instructorRepository;

    public InstructorBusinessRules(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }

    public Task InstructorShouldExistWhenSelected(Instructor? instructor)
    {
        if (instructor == null)
            throw new BusinessException(InstructorsBusinessMessages.InstructorNotExists);
        return Task.CompletedTask;
    }

    public async Task InstructorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Instructor? instructor = await _instructorRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await InstructorShouldExistWhenSelected(instructor);
    }
}