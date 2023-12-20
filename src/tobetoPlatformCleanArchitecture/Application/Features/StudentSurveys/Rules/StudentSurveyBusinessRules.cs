using Application.Features.StudentSurveys.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentSurveys.Rules;

public class StudentSurveyBusinessRules : BaseBusinessRules
{
    private readonly IStudentSurveyRepository _studentSurveyRepository;

    public StudentSurveyBusinessRules(IStudentSurveyRepository studentSurveyRepository)
    {
        _studentSurveyRepository = studentSurveyRepository;
    }

    public Task StudentSurveyShouldExistWhenSelected(StudentSurvey? studentSurvey)
    {
        if (studentSurvey == null)
            throw new BusinessException(StudentSurveysBusinessMessages.StudentSurveyNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentSurveyIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentSurvey? studentSurvey = await _studentSurveyRepository.GetAsync(
            predicate: ss => ss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentSurveyShouldExistWhenSelected(studentSurvey);
    }
}