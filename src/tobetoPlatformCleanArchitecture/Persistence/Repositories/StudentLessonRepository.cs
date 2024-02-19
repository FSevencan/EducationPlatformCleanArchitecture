using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class StudentLessonRepository : EfRepositoryBase<StudentLesson, Guid, BaseDbContext>, IStudentLessonRepository
{
    public StudentLessonRepository(BaseDbContext context) : base(context)
    {

    }

    public async Task<List<StudentLesson>> GetAll(Expression<Func<StudentLesson, bool>> filter = null)
    {
        return filter == null ? Context.Set<StudentLesson>().ToList()
            : Context.Set<StudentLesson>().Where(e => e.DeletedDate == null).Where(filter).ToList();
    }

}