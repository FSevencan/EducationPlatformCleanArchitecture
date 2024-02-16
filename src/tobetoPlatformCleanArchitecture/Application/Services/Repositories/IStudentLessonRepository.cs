using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentLessonRepository : IAsyncRepository<StudentLesson, Guid>, IRepository<StudentLesson, Guid>
{
}