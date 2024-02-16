using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentLessonRepository : EfRepositoryBase<StudentLesson, Guid, BaseDbContext>, IStudentLessonRepository
{
    public StudentLessonRepository(BaseDbContext context) : base(context)
    {
    }
}