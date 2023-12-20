using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentSurveyRepository : EfRepositoryBase<StudentSurvey, Guid, BaseDbContext>, IStudentSurveyRepository
{
    public StudentSurveyRepository(BaseDbContext context) : base(context)
    {
    }
}