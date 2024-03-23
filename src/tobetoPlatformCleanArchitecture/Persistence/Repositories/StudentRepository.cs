using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentRepository : EfRepositoryBase<Student, int, BaseDbContext>, IStudentRepository
{
    public StudentRepository(BaseDbContext context) : base(context)
    {
    }
}