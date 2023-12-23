using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IInstructorRepository : IAsyncRepository<Instructor, int>, IRepository<Instructor, int>
{

}