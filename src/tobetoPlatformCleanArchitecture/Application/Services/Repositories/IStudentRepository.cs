using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentRepository : IAsyncRepository<Student, int>, IRepository<Student, int>
{
}