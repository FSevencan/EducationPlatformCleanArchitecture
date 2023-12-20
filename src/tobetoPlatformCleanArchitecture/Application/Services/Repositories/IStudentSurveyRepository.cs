using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentSurveyRepository : IAsyncRepository<StudentSurvey, Guid>, IRepository<StudentSurvey, Guid>
{
}