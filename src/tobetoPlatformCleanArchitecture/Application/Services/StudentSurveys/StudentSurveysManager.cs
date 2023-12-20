using Application.Features.StudentSurveys.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentSurveys;

public class StudentSurveysManager : IStudentSurveysService
{
    private readonly IStudentSurveyRepository _studentSurveyRepository;
    private readonly StudentSurveyBusinessRules _studentSurveyBusinessRules;

    public StudentSurveysManager(IStudentSurveyRepository studentSurveyRepository, StudentSurveyBusinessRules studentSurveyBusinessRules)
    {
        _studentSurveyRepository = studentSurveyRepository;
        _studentSurveyBusinessRules = studentSurveyBusinessRules;
    }

    public async Task<StudentSurvey?> GetAsync(
        Expression<Func<StudentSurvey, bool>> predicate,
        Func<IQueryable<StudentSurvey>, IIncludableQueryable<StudentSurvey, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentSurvey? studentSurvey = await _studentSurveyRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentSurvey;
    }

    public async Task<IPaginate<StudentSurvey>?> GetListAsync(
        Expression<Func<StudentSurvey, bool>>? predicate = null,
        Func<IQueryable<StudentSurvey>, IOrderedQueryable<StudentSurvey>>? orderBy = null,
        Func<IQueryable<StudentSurvey>, IIncludableQueryable<StudentSurvey, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentSurvey> studentSurveyList = await _studentSurveyRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentSurveyList;
    }

    public async Task<StudentSurvey> AddAsync(StudentSurvey studentSurvey)
    {
        StudentSurvey addedStudentSurvey = await _studentSurveyRepository.AddAsync(studentSurvey);

        return addedStudentSurvey;
    }

    public async Task<StudentSurvey> UpdateAsync(StudentSurvey studentSurvey)
    {
        StudentSurvey updatedStudentSurvey = await _studentSurveyRepository.UpdateAsync(studentSurvey);

        return updatedStudentSurvey;
    }

    public async Task<StudentSurvey> DeleteAsync(StudentSurvey studentSurvey, bool permanent = false)
    {
        StudentSurvey deletedStudentSurvey = await _studentSurveyRepository.DeleteAsync(studentSurvey);

        return deletedStudentSurvey;
    }
}
