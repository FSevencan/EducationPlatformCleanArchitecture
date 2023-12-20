using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentSurveys;

public interface IStudentSurveysService
{
    Task<StudentSurvey?> GetAsync(
        Expression<Func<StudentSurvey, bool>> predicate,
        Func<IQueryable<StudentSurvey>, IIncludableQueryable<StudentSurvey, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<StudentSurvey>?> GetListAsync(
        Expression<Func<StudentSurvey, bool>>? predicate = null,
        Func<IQueryable<StudentSurvey>, IOrderedQueryable<StudentSurvey>>? orderBy = null,
        Func<IQueryable<StudentSurvey>, IIncludableQueryable<StudentSurvey, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<StudentSurvey> AddAsync(StudentSurvey studentSurvey);
    Task<StudentSurvey> UpdateAsync(StudentSurvey studentSurvey);
    Task<StudentSurvey> DeleteAsync(StudentSurvey studentSurvey, bool permanent = false);
}
