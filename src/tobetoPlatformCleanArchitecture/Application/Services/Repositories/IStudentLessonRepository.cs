using Domain.Entities;
using Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Application.Services.Repositories;

public interface IStudentLessonRepository : IAsyncRepository<StudentLesson, Guid>, IRepository<StudentLesson, Guid>
{
    Task<List<StudentLesson>> GetAll(Expression<Func<StudentLesson, bool>> filter = null);
}